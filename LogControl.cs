using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class LogControl : UserControl
    {
        private readonly ActivityLogViewModel _viewModel;

        public LogControl()
        {
            InitializeComponent();
            _viewModel = new ActivityLogViewModel();
            BindControls();
        }

        private void BindControls()
        {
            listLog.DataSource = _viewModel.LogEntries;
            listLog.DisplayMember = "Description";
        }
    }
}