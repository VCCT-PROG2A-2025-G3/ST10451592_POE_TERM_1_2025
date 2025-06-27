using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class TaskControl : UserControl
    {
        private readonly TaskViewModel _viewModel;

        public TaskControl(TaskViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindControls();
        }

        private void BindControls()
        {
            taskListBox.DataSource = _viewModel.Tasks;
            taskListBox.DisplayMember = "Title";
            addTaskButton.Click += (s, e) => ShowAddTaskDialog();
            completeTaskButton.Click += (s, e) => _viewModel.CompleteTask(null);
            deleteTaskButton.Click += (s, e) => _viewModel.DeleteTask(null);
        }

        private void ShowAddTaskDialog()
        {
            using (var form = new AddTaskForm(_viewModel))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _viewModel.AddTask(null); // Trigger update (dialog handles task creation)
                }
            }
        }
    }
}