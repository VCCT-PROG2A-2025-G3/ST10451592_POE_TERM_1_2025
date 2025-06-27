namespace CybersecurityApp
{
    partial class TaskControl
    {
        private System.ComponentModel.IContainer components = null;

        private ListBox taskListBox;
        private Button addTaskButton;
        private Button completeTaskButton;
        private Button deleteTaskButton;

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
            this.taskListBox = new System.Windows.Forms.ListBox();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.completeTaskButton = new System.Windows.Forms.Button();
            this.deleteTaskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // taskListBox
            // 
            this.taskListBox.Location = new System.Drawing.Point(3, 3);
            this.taskListBox.Name = "taskListBox";
            this.taskListBox.Size = new System.Drawing.Size(762, 495);
            this.taskListBox.TabIndex = 0;
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(3, 504);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(75, 23);
            this.addTaskButton.TabIndex = 1;
            this.addTaskButton.Text = "Add Task";
            // 
            // completeTaskButton
            // 
            this.completeTaskButton.Location = new System.Drawing.Point(84, 504);
            this.completeTaskButton.Name = "completeTaskButton";
            this.completeTaskButton.Size = new System.Drawing.Size(75, 23);
            this.completeTaskButton.TabIndex = 2;
            this.completeTaskButton.Text = "Complete";
            // 
            // deleteTaskButton
            // 
            this.deleteTaskButton.Location = new System.Drawing.Point(165, 504);
            this.deleteTaskButton.Name = "deleteTaskButton";
            this.deleteTaskButton.Size = new System.Drawing.Size(75, 23);
            this.deleteTaskButton.TabIndex = 3;
            this.deleteTaskButton.Text = "Delete";
            // 
            // TaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteTaskButton);
            this.Controls.Add(this.completeTaskButton);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.taskListBox);
            this.Name = "TaskControl";
            this.Size = new System.Drawing.Size(768, 548);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}