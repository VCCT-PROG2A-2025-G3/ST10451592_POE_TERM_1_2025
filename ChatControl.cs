using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class ChatControl : UserControl
    {
        private readonly ChatViewModel _viewModel;

        public ChatControl()
        {
            InitializeComponent();
            _viewModel = new ChatViewModel();
            BindControls();
        }

        private void BindControls()
        {
            txtResponse.DataBindings.Add("Text", _viewModel, "Response", false, DataSourceUpdateMode.OnPropertyChanged);
            txtInput.DataBindings.Add("Text", _viewModel, "UserInput", true, DataSourceUpdateMode.OnPropertyChanged);
            btnSend.Click += (s, e) => _viewModel.Send(null);
        }
    }
}