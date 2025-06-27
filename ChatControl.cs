using System;
using System.Windows.Forms;
using CybersecurityChatbot; // Namespace for chatbot classes

namespace CybersecurityApp
{
    public partial class ChatControl : UserControl
    {
        // User control for the chat interface
        private readonly ChatbotViewModel _viewModel; // View model for chatbot data
        private readonly StartChat _chatSession; // Manages the chat session

        public ChatControl(ChatbotViewModel viewModel)
        {
            InitializeComponent(); // Initializes GUI components from the designer
            _viewModel = viewModel; // Sets the view model instance
            _chatSession = new StartChat(); // Initializes the chat session
            inputTextBox.KeyDown += InputTextBox_KeyDown; // Event handler for Enter key
            StartChatSession(); // Starts the chat with a welcome message
        }

        private void StartChatSession()
        {
            // Displays the initial welcome message in the chat display
            UpdateChatDisplay("Welcome! I'm your Cybersecurity Awareness Bot. Type your name to begin.");
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Handles input when Enter key is pressed
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                string userInput = inputTextBox.Text.Trim(); // Gets and trims user input
                inputTextBox.Clear(); // Clears the input field
                string response = _chatSession.InitiateChatStep(userInput); // Processes input
                UpdateChatDisplay($"You: {userInput}"); // Displays user input
                if (!string.IsNullOrEmpty(response))
                {
                    UpdateChatDisplay($"Chatbot: {response}"); // Displays chatbot response
                }
                inputTextBox.Focus(); // Refocuses the input field
            }
        }

        private void UpdateChatDisplay(string message)
        {
            // Appends a message to the chat display and scrolls to the latest entry
            chatDisplayTextBox.AppendText($"{message}{Environment.NewLine}");
            chatDisplayTextBox.ScrollToCaret();
        }
    }
}