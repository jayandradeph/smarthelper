using Newtonsoft.Json;
using NTDLS.Persistence;
using SmartHelper.Hooks;
using SmartHelper.Recording;
using SmartHelper.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Quartz;
using Quartz.Impl;
using SmartHelper.Scheduler;

namespace SmartHelper.Forms
{
    public partial class FormMain : Form
    {
        private IScheduler scheduler;
        private string taskPlaying = String.Empty;
        private readonly ActionRecorder _actionRecorder = new();
        private readonly ActionPlayer _actionPlayer = new();
        private readonly HashSet<Keys> acceptableKeys = new HashSet<Keys>
        {
            Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6,
            Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12,
            Keys.Insert, Keys.Home, Keys.PageUp, Keys.PageDown, Keys.Delete, Keys.End
        };
        public FormMain()
        {
            InitializeComponent();
            StartScheduler();
        }

        private async void StartScheduler()
        {
            // Create a scheduler factory
            StdSchedulerFactory factory = new StdSchedulerFactory();

            // Get a scheduler
            scheduler = await factory.GetScheduler();
            await scheduler.Start();

            var recordings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new List<PersistedRecording>());
            var filteredRecordings = recordings.Where(r => r.HotKey.Equals("Time Trigger")).ToList();

            foreach (var recording in filteredRecordings)
            {
                ScheduleRecordingJob(recording);
            }
        }

        private async void ScheduleRecordingJob(PersistedRecording recording)
        {
            // Define the job and tie it to our RecordingJob class
            IJobDetail job = JobBuilder.Create<RecordingJob>()
                .WithIdentity($"recordingJob_{recording.Name}", "group1")
                .UsingJobData("recordingName", recording.Name)
                .Build();

            // Extract the time part from the schedule
            string timeString = CronHelper.ExtractTime(recording.Schedule);

            // Convert the schedule time to a CRON expression
            string cronExpression = CronHelper.ConvertTimeToCronExpression(timeString);

            // Trigger the job to run daily at 4:00 AM
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity($"recordingTrigger_{recording.Name}", "group1")
                .StartNow()
                .WithCronSchedule(cronExpression)
                .Build();

            // Tell Quartz to schedule the job using our trigger
            await scheduler.ScheduleJob(job, trigger);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            KeyboardHook.OnKeyboardEventInterceptor += KeyboardHook_OnKeyboardEventInterceptor;
            _actionPlayer.OnStopped += ActionPlayer_OnStopped;
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            using var form = new FormTaskLists();
            form.ShowDialog();
        }

        private void btnRecord_MouseHover(object sender, EventArgs e)
        {
            toolTipBtn.Show("Press F12 Key to Record", btnRecord);
        }

        private void ActionPlayer_OnStopped(ActionPlayer sender)
        {
            if (InvokeRequired)
            {
                Invoke(() => ActionPlayer_OnStopped(sender));
                return;
            }

            ToggleFormVisualStates();
        }

        private void KeyboardHook_OnKeyboardEventInterceptor(Keys key, ButtonDisposition keyboardButtonDirection)
        {
            // Check if the key should be ignored
            if (!acceptableKeys.Contains(key))
            {
                return; // Do nothing if the key is in the ignore list
            }

            if (key == Enum.Parse<Keys>(Program.Settings.RecordHotkey) && keyboardButtonDirection == ButtonDisposition.Up)
            {
                if (_actionPlayer.IsRunning)
                {
                    //We cannot start/stop the recorder while the player is running.
                    return;
                }

                if (_actionRecorder.IsRunning)
                    StopRecord();
                else StartRecord();

            }
            else
            {
                var recordings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new List<PersistedRecording>());
                // Filter the list based on the HotKey property containing the key string
                var filteredRecordings = recordings.Where(r => r.HotKey.Equals(key.ToString())).FirstOrDefault();

                if (filteredRecordings != null && keyboardButtonDirection == ButtonDisposition.Up)
                {
                    if (_actionRecorder.IsRunning)
                    {
                        // We cannot start/stop the player while the recorder is running.
                        return;
                    }

                    if (_actionPlayer.IsRunning)
                    {
                        StopPlay();
                    }
                    else
                    {
                        taskPlaying = filteredRecordings.Name;
                        StartPlay(filteredRecordings);
                    }
                }
            }
        }

        private void StartPlay(PersistedRecording recording)
        {
            if (recording != null)
            {
                _actionPlayer.Start(recording);
            }
            ToggleFormVisualStates();
        }

        private void StopPlay()
        {
            _actionPlayer.Stop();
            ToggleFormVisualStates();
        }

        private void StartRecord()
        {
            _actionRecorder.Start();
            ToggleFormVisualStates();
        }

        private void StopRecord()
        {
            _actionRecorder.Stop();

            var recordings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new List<PersistedRecording>());
            var recording = new PersistedRecording()
            {
                Name = $"Recording {(recordings.Count + 1):n0}",
                CreatedDate = DateTime.Now,
                Actions = _actionRecorder.Actions
            };

            SaveRecordings(recording);

            ToggleFormVisualStates();
        }

        private void SaveRecordings(PersistedRecording recording)
        {
            var recordings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new List<PersistedRecording>());
            recordings.Add(recording);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            LocalUserApplicationData.SaveToDisk("SmartHelper", recordings, settings);
        }

        private void ToggleFormVisualStates()
        {
            btnRecord.Text = _actionRecorder.IsRunning ? "RECORDING" : "RECORD";

            btnRecord.Enabled = !_actionRecorder.IsRunning && !_actionPlayer.IsRunning;

            btnTasks.Text = _actionPlayer.IsRunning ? $"Playing {taskPlaying}" : "TASK LISTS";

            btnTasks.Enabled = !_actionRecorder.IsRunning && !_actionPlayer.IsRunning;
        }

        private async void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Shut down the scheduler when the application closes
            if (scheduler != null)
            {
                await scheduler.Shutdown();
            }
        }
    }
}
