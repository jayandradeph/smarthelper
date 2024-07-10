namespace SmartHelper.Forms
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnRecord = new Button();
            btnTasks = new Button();
            toolTipBtn = new ToolTip(components);
            SuspendLayout();
            // 
            // btnRecord
            // 
            btnRecord.BackColor = SystemColors.Highlight;
            btnRecord.Cursor = Cursors.Hand;
            btnRecord.FlatAppearance.BorderSize = 0;
            btnRecord.FlatStyle = FlatStyle.Flat;
            btnRecord.Font = new Font("Segoe UI Light", 24F);
            btnRecord.ForeColor = SystemColors.ControlLightLight;
            btnRecord.Location = new Point(57, 12);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(346, 59);
            btnRecord.TabIndex = 0;
            btnRecord.Text = "RECORD";
            btnRecord.UseVisualStyleBackColor = false;
            btnRecord.MouseHover += btnRecord_MouseHover;
            // 
            // btnTasks
            // 
            btnTasks.BackColor = SystemColors.ActiveCaption;
            btnTasks.Cursor = Cursors.Hand;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI Light", 24F);
            btnTasks.ForeColor = SystemColors.ControlLightLight;
            btnTasks.Location = new Point(57, 92);
            btnTasks.Name = "btnTasks";
            btnTasks.Size = new Size(346, 59);
            btnTasks.TabIndex = 1;
            btnTasks.Text = "TASK LISTS";
            btnTasks.UseVisualStyleBackColor = false;
            btnTasks.Click += btnTasks_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 163);
            Controls.Add(btnTasks);
            Controls.Add(btnRecord);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(480, 202);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SmartHelper";
            TopMost = true;
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnRecord;
        private Button btnTasks;
        private ToolTip toolTipBtn;
    }
}