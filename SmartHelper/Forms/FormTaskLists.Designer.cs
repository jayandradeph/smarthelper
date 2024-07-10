namespace SmartHelper.Forms
{
    partial class FormTaskLists
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaskLists));
            listViewHistory = new ListView();
            columnTaskName = new ColumnHeader();
            columnTaskHotkey = new ColumnHeader();
            SuspendLayout();
            // 
            // listViewHistory
            // 
            listViewHistory.Columns.AddRange(new ColumnHeader[] { columnTaskName, columnTaskHotkey });
            listViewHistory.FullRowSelect = true;
            listViewHistory.GridLines = true;
            listViewHistory.LabelEdit = true;
            listViewHistory.Location = new Point(12, 12);
            listViewHistory.Name = "listViewHistory";
            listViewHistory.Size = new Size(433, 329);
            listViewHistory.TabIndex = 0;
            listViewHistory.UseCompatibleStateImageBehavior = false;
            listViewHistory.View = View.Details;
            // 
            // columnTaskName
            // 
            columnTaskName.Text = "Task Name";
            columnTaskName.Width = 300;
            // 
            // columnTaskHotkey
            // 
            columnTaskHotkey.Text = "HotKey";
            columnTaskHotkey.Width = 150;
            // 
            // FormTaskLists
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 353);
            Controls.Add(listViewHistory);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(473, 392);
            Name = "FormTaskLists";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Lists";
            TopMost = true;
            Load += FormTaskLists_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewHistory;
        private ColumnHeader columnTaskName;
        private ColumnHeader columnTaskHotkey;
    }
}