using Newtonsoft.Json;
using NTDLS.Persistence;
using Quartz.Impl;
using Quartz;
using SmartHelper.Recording;
using SmartHelper.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHelper.Forms
{
    public partial class FormTaskLists : Form
    {
        private bool _isGridPopulating = false;

        public FormTaskLists()
        {
            InitializeComponent();
        }

        private void FormTaskLists_Load(object sender, EventArgs e)
        {
            listViewHistory.AfterLabelEdit += (object? sender, LabelEditEventArgs e) =>
            {
                listViewHistory.Items[e.Item].Text = e.Label;

                SaveRecordings();
            };

            listViewHistory.ItemChecked += ListViewHistory_ItemChecked;
            listViewHistory.MouseDown += ListViewHistory_MouseDown;
            listViewHistory.KeyUp += ListViewHistory_KeyUp;

            LoadRecordings();

            FormClosed += (object? sender, FormClosedEventArgs e) => SaveRecordings();
        }

        private void ListViewHistory_MouseDown(object? sender, MouseEventArgs e)
        {
            _isGridPopulating = true;
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && listViewHistory.SelectedItems.Count == 1)
            {
                var clickedItem = listViewHistory.SelectedItems[0];
                var recording = (PersistedRecording?)clickedItem.Tag;
                if (recording != null)
                {
                    using var form = new FormEditTask(recording);
                    if (form.ShowDialog() == DialogResult.OK && form.persistedRecording != null)
                    {
                        clickedItem.Text = form.persistedRecording.Name;
                        clickedItem.Tag = form.persistedRecording;
                        SaveRecordings();
                        LoadRecordings();
                    }
                }
            }
            _isGridPopulating = false;
        }

        private void ListViewHistory_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (listViewHistory.SelectedItems.Count > 0)
                {
                    var item = listViewHistory.SelectedItems[0];
                    item.BeginEdit();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (listViewHistory.SelectedItems.Count > 0)
                {
                    var item = listViewHistory.SelectedItems[0];

                    if (MessageBox.Show($"Delete the recording '{item.Text}'", "SmartHelper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                    listViewHistory.Items.Remove(item);

                    SaveRecordings();
                }
            }
        }

        private void ListViewHistory_ItemChecked(object? sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == false || _isGridPopulating)
            {
                return;
            }

            foreach (ListViewItem item in listViewHistory.Items)
            {
                if (item.Index != e.Item.Index)
                {
                    item.Checked = false;
                }
            }
        }

        private async void SaveRecordings()
        {
            List<PersistedRecording> recordings = new();

            foreach (ListViewItem item in listViewHistory.Items)
            {
                var rowPersist = (PersistedRecording?)item.Tag;
                if (rowPersist != null)
                {
                    rowPersist.Selected = item.Checked;
                    rowPersist.Name = item.Text;
                    recordings.Add(rowPersist);
                }
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            LocalUserApplicationData.SaveToDisk("SmartHelper", recordings, settings);

            // Create a scheduler factory
            StdSchedulerFactory factory = new StdSchedulerFactory();

            // Get a scheduler
            IScheduler scheduler = await factory.GetScheduler();

            //Clear all scheduled jobs
            await scheduler.Clear();

            var filteredRecordings = recordings.Where(r => r.HotKey.Equals("Time Trigger")).ToList();

            foreach (var recording in filteredRecordings)
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
        }

        private void LoadRecordings()
        {
            _isGridPopulating = true;
            var recordings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new List<PersistedRecording>());

            listViewHistory.Items.Clear();

            foreach (var recording in recordings)
            {
                var item = new ListViewItem(new string[] { recording.Name, recording.HotKey });
                listViewHistory.Items.Add(item).Tag = recording;
                item.Checked = recording.Selected;
            }
            _isGridPopulating = false;
        }
    }
}
