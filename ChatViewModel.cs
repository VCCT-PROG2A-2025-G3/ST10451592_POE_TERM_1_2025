using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CybersecurityApp
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private string _userInput;
        private string _response;

        public string UserInput
        {
            get => _userInput;
            set { _userInput = value; OnPropertyChanged(); }
        }

        public string Response
        {
            get => _response;
            set { _response = value; OnPropertyChanged(); }
        }

        public void Send(object parameter)
        {
            if (string.IsNullOrWhiteSpace(UserInput)) return;

            string[] keywords = { "task", "quiz", "chat", "log", "phishing", "encryption" };
            string detectedKeywords = string.Join(", ", keywords.Where(k => UserInput.ToLower().Contains(k)));

            if (!string.IsNullOrEmpty(detectedKeywords))
            {
                Response = $"Detected keywords: {detectedKeywords}. Processing your request...";
            }
            else
            {
                Response = "No keywords detected. Try mentioning 'task', 'quiz', 'chat', 'log', or cybersecurity terms like 'phishing' or 'encryption'.";
            }

            UserInput = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}