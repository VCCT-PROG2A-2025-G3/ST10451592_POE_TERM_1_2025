using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class TaskControl : UserControl
    {
        // User control for task management interface
        private readonly TaskManager _taskManager; // Manages task data

        public TaskControl(TaskManager taskManager)
        {
            InitializeComponent(); // Initializes GUI components from the designer
            _taskManager = taskManager ?? throw new ArgumentNullException(nameof(taskManager)); // Sets task manager instance
            PopulateTasks(); // Populates the task list on initialization
        }

        private void PopulateTasks()
        {
            // Updates the task list with current tasks
            taskListBox.Items.Clear();
            foreach (var task in _taskManager.Tasks)
            {
                taskListBox.Items.Add($"{task.Title} (Reminder: {task.Reminder?.ToString("g") ?? "None"}) - {(task.IsCompleted ? "Completed" : "Pending")}");
            }
        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            // Adds a new task based on user input
            string title = taskTitleTextBox.Text;
            string description = taskDescriptionTextBox.Text;
            if (DateTime.TryParse(taskReminderDateTimePicker.Text, out DateTime reminder))
            {
                _taskManager.AddTask(title, description, reminder);
            }
            else
            {
                _taskManager.AddTask(title, description, null);
            }
            PopulateTasks();
        }

        private void completeTaskButton_Click(object sender, EventArgs e)
        {
            // Marks the selected task as completed
            if (taskListBox.SelectedIndex >= 0)
            {
                _taskManager.CompleteTask(taskListBox.SelectedIndex);
                PopulateTasks();
            }
        }

        private void deleteTaskButton_Click(object sender, EventArgs e)
        {
            // Deletes the selected task
            if (taskListBox.SelectedIndex >= 0)
            {
                _taskManager.DeleteTask(taskListBox.SelectedIndex);
                PopulateTasks();
            }
        }
    }
}