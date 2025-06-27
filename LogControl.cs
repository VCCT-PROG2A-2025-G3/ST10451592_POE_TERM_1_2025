using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class LogControl : UserControl
    {
        private readonly ActivityLogViewModel _viewModel;

        public LogControl(ActivityLogViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindControls();
        }

        private void BindControls()
        {
            logListBox.DataSource = _viewModel.LogEntries;
            logListBox.DisplayMember = "Description";
            showMoreButton.Click += (s, e) => _viewModel.ShowMore();
        }
    }
}