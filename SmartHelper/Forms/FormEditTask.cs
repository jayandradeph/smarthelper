using Newtonsoft.Json;
using NTDLS.Persistence;
using Quartz.Util;
using SmartHelper.Recording;
using System.Windows.Forms;

namespace SmartHelper.Forms
{
    internal partial class FormEditTask : Form
    {
        public PersistedRecording? persistedRecording { get; private set; }
        public FormEditTask()
        {
            InitializeComponent();
        }
        public FormEditTask(PersistedRecording recording)
        {
            InitializeComponent();

            persistedRecording = recording;

            AcceptButton = buttonSave;

            textBoxName.Text = recording.Name;
            textBoxSpeed.Text = recording.Speed.ToString();
            textBoxLoop.Text = recording.Repetitions.ToString();
            textBoxDelay.Text = recording.RepetitionDelay.ToString();
            comboBoxKey.Text = recording.HotKey.ToString();
            dtmSchedule.Text = recording.Schedule.ToString();

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (persistedRecording != null)
            {

                if (!double.TryParse(textBoxSpeed.Text, out var speed))
                {
                    speed = 1;
                }

                if (!int.TryParse(textBoxLoop.Text, out var repetitions))
                {
                    repetitions = 0;
                }

                if (!int.TryParse(textBoxDelay.Text, out var repetitionDelay))
                {
                    repetitionDelay = 1000;
                }

                if(comboBoxKey.Text == "Time Trigger")
                {
                    repetitions = 1;
                }

                if (textBoxName.Text != persistedRecording.Name)
                {
                    var recordings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new List<PersistedRecording>());
                    // Filter the list based on the HotKey property containing the key string
                    var filteredRecordings = recordings.Where(r => r.Name.Equals(textBoxName.Text)).ToList();

                    if (filteredRecordings.Count > 0)
                    {
                        MessageBox.Show("Task Name already in use.");
                        return;
                    }
                }

                var newRecording = new PersistedRecording()
                {
                    CreatedDate = persistedRecording.CreatedDate,
                    Name = textBoxName.Text,
                    Selected = persistedRecording.Selected,
                    Speed = speed,
                    Repetitions = repetitions,
                    RepetitionDelay = repetitionDelay,
                    HotKey = comboBoxKey.Text,
                    Schedule = dtmSchedule.Value.ToString(),
                    Actions = persistedRecording.Actions
                };

                persistedRecording = newRecording;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void comboBoxKey_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxKey.Text == "Time Trigger")
            {
                lblSchedule.Visible = true;
                dtmSchedule.Visible = true;
                textBoxLoop.Text = "1";
            } else
            {
                lblSchedule.Visible = false;
                dtmSchedule.Visible = false;

                if (persistedRecording.HotKey.ToString() != comboBoxKey.Text)
                {
                    var recordings = LocalUserApplicationData.LoadFromDisk("SmartHelper", new List<PersistedRecording>());
                    // Filter the list based on the HotKey property containing the key string
                    var filteredRecordings = recordings.Where(r => r.HotKey.Equals(comboBoxKey.Text.ToString())).FirstOrDefault();
                    if (filteredRecordings != null)
                    {
                        MessageBox.Show("Key is already in use, please select another one.");
                        comboBoxKey.Text = persistedRecording.HotKey;
                    }
                }
            }
        }
    }
}
