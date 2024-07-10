using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTDLS.Persistence;
using Quartz;
using SmartHelper.Recording;

namespace SmartHelper.Scheduler
{
    public class RecordingJob : IJob
    {
        private readonly ActionPlayer _actionPlayer = new();
        public Task Execute(IJobExecutionContext context)
        {
            var recordingName = context.MergedJobDataMap.GetString("recordingName");
            var recordings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new List<PersistedRecording>());
            var recording = recordings.FirstOrDefault(r => r.Name == recordingName);

            if (recording != null)
            {
                StartPlay(recording);
            }
            else
            {
                Console.WriteLine("Recording not found.");
            }

            return Task.CompletedTask;
        }

        private void StartPlay(PersistedRecording recording)
        {
            if (recording != null)
            {
                _actionPlayer.Start(recording);
            }
        }
    }
}
