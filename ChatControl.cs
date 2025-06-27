using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class ChatControl : UserControl
    {
        private readonly ChatbotViewModel _viewModel;

        public ChatControl(ChatbotViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            inputTextBox.KeyDown += InputTextBox_KeyDown;
            UpdateChatDisplay();
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                string userInput = inputTextBox.Text.Trim();
                string response = _viewModel.ProcessInput(userInput);
                chatDisplayTextBox.AppendText($"You: {userInput}{Environment.NewLine}");
                chatDisplayTextBox.AppendText($"Bot: {response}{Environment.NewLine}{Environment.NewLine}");
                inputTextBox.Clear();
                UpdateChatDisplay();
            }
        }

        private void UpdateChatDisplay()
        {
            chatDisplayTextBox.ScrollToCaret();
        }
    }
}