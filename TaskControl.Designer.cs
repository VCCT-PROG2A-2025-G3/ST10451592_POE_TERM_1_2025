namespace CybersecurityApp
{
    partial class TaskControl
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private DateTimePicker reminderDateTimePicker;
        private Button addTaskButton;
        private Button deleteTaskButton;
        private Button completeTaskButton;
        private ListView taskListView;

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
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.reminderDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.deleteTaskButton = new System.Windows.Forms.Button();
            this.completeTaskButton = new System.Windows.Forms.Button();
            this.taskListView = new System.Windows.Forms.ListView();
            this.taskListView.Columns.Add("Title", 150);
            this.taskListView.Columns.Add("Description", 200);
            this.taskListView.Columns.Add("Reminder", 120);
            this.taskListView.Columns.Add("Completed", 80);
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(10, 10);
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(10, 40);
            this.descriptionTextBox.Size = new System.Drawing.Size(200, 20);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // reminderDateTimePicker
            // 
            this.reminderDateTimePicker.Location = new System.Drawing.Point(10, 70);
            this.reminderDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.reminderDateTimePicker.TabIndex = 2;
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(220, 10);
            this.addTaskButton.Text = "Add Task";
            this.addTaskButton.Size = new System.Drawing.Size(75, 23);
            this.addTaskButton.TabIndex = 3;
            // 
            // deleteTaskButton
            // 
            this.deleteTaskButton.Location = new System.Drawing.Point(220, 40);
            this.deleteTaskButton.Text = "Delete Task";
            this.deleteTaskButton.Size = new System.Drawing.Size(75, 23);
            this.deleteTaskButton.TabIndex = 4;
            // 
            // completeTaskButton
            // 
            this.completeTaskButton.Location = new System.Drawing.Point(220, 70);
            this.completeTaskButton.Text = "Complete Task";
            this.completeTaskButton.Size = new System.Drawing.Size(75, 23);
            this.completeTaskButton.TabIndex = 5;
            // 
            // taskListView
            // 
            this.taskListView.Location = new System.Drawing.Point(10, 100);
            this.taskListView.Size = new System.Drawing.Size(550, 300);
            this.taskListView.View = System.Windows.Forms.View.Details;
            this.taskListView.TabIndex = 6;
            // 
            // TaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.taskListView);
            this.Controls.Add(this.completeTaskButton);
            this.Controls.Add(this.deleteTaskButton);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.reminderDateTimePicker);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Name = "TaskControl";
            this.Size = new System.Drawing.Size(570, 410);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}