namespace CybersecurityApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControl;
        private TabPage tabChat;
        private TabPage tabTasks;
        private TabPage tabQuiz;
        private TabPage tabLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.tabQuiz = new System.Windows.Forms.TabPage();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabChat);
            this.tabControl.Controls.Add(this.tabTasks);
            this.tabControl.Controls.Add(this.tabQuiz);
            this.tabControl.Controls.Add(this.tabLog);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 576);
            this.tabControl.TabIndex = 0;
            // 
            // tabChat
            // 
            this.tabChat.Location = new System.Drawing.Point(4, 22);
            this.tabChat.Name = "tabChat";
            this.tabChat.Size = new System.Drawing.Size(768, 550);
            this.tabChat.TabIndex = 0;
            this.tabChat.Text = "Chat";
            // 
            // tabTasks
            // 
            this.tabTasks.Location = new System.Drawing.Point(4, 22);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Size = new System.Drawing.Size(768, 550);
            this.tabTasks.TabIndex = 1;
            this.tabTasks.Text = "Tasks";
            // 
            // tabQuiz
            // 
            this.tabQuiz.Location = new System.Drawing.Point(4, 22);
            this.tabQuiz.Name = "tabQuiz";
            this.tabQuiz.Size = new System.Drawing.Size(768, 550);
            this.tabQuiz.TabIndex = 2;
            this.tabQuiz.Text = "Quiz";
            // 
            // tabLog
            // 
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(768, 550);
            this.tabLog.TabIndex = 3;
            this.tabLog.Text = "Log";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Cybersecurity Assistant";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}