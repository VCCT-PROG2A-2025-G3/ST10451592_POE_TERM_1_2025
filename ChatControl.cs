using System;
using System.Windows.Forms;
using CybersecurityChatbot; // Adjust namespace if different

namespace CybersecurityApp
{
    public partial class ChatControl : UserControl
    {
        private readonly ChatbotViewModel _viewModel;
        private readonly StartChat _chatSession;

        public ChatControl(ChatbotViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _chatSession = new StartChat();
            inputTextBox.KeyDown += InputTextBox_KeyDown;
            StartChatSession();
        }

        private void StartChatSession()
        {
            UpdateChatDisplay("Welcome! I'm your Cybersecurity Awareness Bot. Type your name to begin.");
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                string userInput = inputTextBox.Text.Trim();
                inputTextBox.Clear();

                string response = _chatSession.InitiateChatStep(userInput);
                UpdateChatDisplay($"You: {userInput}");
                if (!string.IsNullOrEmpty(response))
                {
                    UpdateChatDisplay($"Chatbot: {response}");
                }

                inputTextBox.Focus();
            }
        }

        private void UpdateChatDisplay(string message)
        {
            chatDisplayTextBox.AppendText($"{message}{Environment.NewLine}");
            chatDisplayTextBox.ScrollToCaret();
        }
    }
}