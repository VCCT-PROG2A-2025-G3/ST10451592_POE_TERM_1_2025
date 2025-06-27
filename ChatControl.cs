using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class ChatControl : UserControl
    {
        private readonly ChatViewModel _viewModel;

        public ChatControl(ChatViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindControls();
        }

        private void BindControls()
        {
            responseTextBox.DataBindings.Add("Text", _viewModel, "Response", false, DataSourceUpdateMode.OnPropertyChanged);
            inputTextBox.DataBindings.Add("Text", _viewModel, "UserInput", true, DataSourceUpdateMode.OnPropertyChanged);
            sendButton.Click += (s, e) => _viewModel.Send(null);
        }
    }
}