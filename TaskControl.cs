using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class TaskControl : UserControl
    {
        private readonly TaskViewModel _viewModel;

        public TaskControl()
        {
            InitializeComponent();
            _viewModel = new TaskViewModel();
            BindControls();
        }

        private void BindControls()
        {
            listTasks.DataSource = _viewModel.Tasks;
            listTasks.DisplayMember = "Title";
            btnAdd.Click += (s, e) => _viewModel.AddTask(null);
            btnComplete.Click += (s, e) => _viewModel.CompleteTask(null);
            btnDelete.Click += (s, e) => _viewModel.DeleteTask(null);
        }
    }
}