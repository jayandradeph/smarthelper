namespace SmartHelper.Forms
{
    partial class FormEditTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditTask));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonSave = new Button();
            textBoxName = new TextBox();
            textBoxSpeed = new TextBox();
            textBoxLoop = new TextBox();
            textBoxDelay = new TextBox();
            label5 = new Label();
            comboBoxKey = new ComboBox();
            lblSchedule = new Label();
            dtmSchedule = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Light", 14F);
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Light", 14F);
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 1;
            label2.Text = "Speed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Light", 14F);
            label3.Location = new Point(310, 71);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 2;
            label3.Text = "Delay";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Light", 14F);
            label4.Location = new Point(159, 71);
            label4.Name = "label4";
            label4.Size = new Size(54, 25);
            label4.TabIndex = 3;
            label4.Text = "Loop";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = SystemColors.Highlight;
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI Light", 15F);
            buttonSave.ForeColor = SystemColors.ControlLightLight;
            buttonSave.Location = new Point(319, 174);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(141, 40);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "SAVE";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI Light", 14F);
            textBoxName.Location = new Point(73, 21);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(377, 32);
            textBoxName.TabIndex = 5;
            // 
            // textBoxSpeed
            // 
            textBoxSpeed.Font = new Font("Segoe UI Light", 14F);
            textBoxSpeed.Location = new Point(73, 68);
            textBoxSpeed.Name = "textBoxSpeed";
            textBoxSpeed.Size = new Size(80, 32);
            textBoxSpeed.TabIndex = 6;
            // 
            // textBoxLoop
            // 
            textBoxLoop.Font = new Font("Segoe UI Light", 14F);
            textBoxLoop.Location = new Point(219, 68);
            textBoxLoop.Name = "textBoxLoop";
            textBoxLoop.Size = new Size(80, 32);
            textBoxLoop.TabIndex = 7;
            // 
            // textBoxDelay
            // 
            textBoxDelay.Font = new Font("Segoe UI Light", 14F);
            textBoxDelay.Location = new Point(370, 68);
            textBoxDelay.Name = "textBoxDelay";
            textBoxDelay.Size = new Size(80, 32);
            textBoxDelay.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Light", 14F);
            label5.Location = new Point(12, 120);
            label5.Name = "label5";
            label5.Size = new Size(41, 25);
            label5.TabIndex = 9;
            label5.Text = "Key";
            // 
            // comboBoxKey
            // 
            comboBoxKey.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKey.Font = new Font("Segoe UI Light", 14F);
            comboBoxKey.FormattingEnabled = true;
            comboBoxKey.Items.AddRange(new object[] { "", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "Insert", "Home", "PageUp", "Next", "Delete", "End", "Time Trigger" });
            comboBoxKey.Location = new Point(73, 117);
            comboBoxKey.Name = "comboBoxKey";
            comboBoxKey.Size = new Size(122, 33);
            comboBoxKey.TabIndex = 10;
            comboBoxKey.SelectedValueChanged += comboBoxKey_SelectedValueChanged;
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Font = new Font("Segoe UI Light", 14F);
            lblSchedule.Location = new Point(219, 120);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(84, 25);
            lblSchedule.TabIndex = 11;
            lblSchedule.Text = "Schedule";
            lblSchedule.Visible = false;
            // 
            // dtmSchedule
            // 
            dtmSchedule.CalendarFont = new Font("Segoe UI Light", 14F);
            dtmSchedule.CustomFormat = "HH:mm";
            dtmSchedule.Font = new Font("Segoe UI Light", 14F);
            dtmSchedule.Format = DateTimePickerFormat.Custom;
            dtmSchedule.Location = new Point(309, 118);
            dtmSchedule.Name = "dtmSchedule";
            dtmSchedule.ShowUpDown = true;
            dtmSchedule.Size = new Size(141, 32);
            dtmSchedule.TabIndex = 12;
            dtmSchedule.Visible = false;
            // 
            // FormEditTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 220);
            Controls.Add(dtmSchedule);
            Controls.Add(lblSchedule);
            Controls.Add(comboBoxKey);
            Controls.Add(label5);
            Controls.Add(textBoxDelay);
            Controls.Add(textBoxLoop);
            Controls.Add(textBoxSpeed);
            Controls.Add(textBoxName);
            Controls.Add(buttonSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(487, 259);
            Name = "FormEditTask";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Task";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonSave;
        private TextBox textBoxName;
        private TextBox textBoxSpeed;
        private TextBox textBoxLoop;
        private TextBox textBoxDelay;
        private Label label5;
        private ComboBox comboBoxKey;
        private Label lblSchedule;
        private DateTimePicker dtmSchedule;
    }
}