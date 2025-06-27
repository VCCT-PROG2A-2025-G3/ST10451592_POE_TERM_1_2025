using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class TaskControl : UserControl
    {
        private readonly TaskManager _taskManager;

        public TaskControl(TaskManager taskManager)
        {
            InitializeComponent();
            _taskManager = taskManager;
            LoadTasks();
            addTaskButton.Click += AddTaskButton_Click;
            deleteTaskButton.Click += DeleteTaskButton_Click;
            completeTaskButton.Click += CompleteTaskButton_Click;
        }

        private void LoadTasks()
        {
            taskListView.Items.Clear();
            foreach (var task in _taskManager.Tasks)
            {
                var item = new ListViewItem(new[] { task.Title, task.Description, task.Reminder?.ToString() ?? "None", task.IsCompleted ? "Yes" : "No" });
                taskListView.Items.Add(item);
            }
        }

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Title and description are required.");
                return;
            }
            _taskManager.AddTask(titleTextBox.Text, descriptionTextBox.Text, reminderDateTimePicker.Value);
            LoadTasks();
            ClearInputs();
        }

        private void DeleteTaskButton_Click(object sender, EventArgs e)
        {
            if (taskListView.SelectedItems.Count > 0)
            {
                int index = taskListView.SelectedIndices[0];
                _taskManager.DeleteTask(index);
                LoadTasks();
            }
        }

        private void CompleteTaskButton_Click(object sender, EventArgs e)
        {
            if (taskListView.SelectedItems.Count > 0)
            {
                int index = taskListView.SelectedIndices[0];
                _taskManager.CompleteTask(index);
                LoadTasks();
            }
        }

        private void ClearInputs()
        {
            titleTextBox.Clear();
            descriptionTextBox.Clear();
            reminderDateTimePicker.Value = DateTime.Now;
        }
    }
}