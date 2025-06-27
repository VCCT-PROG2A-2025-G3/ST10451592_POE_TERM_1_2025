using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CybersecurityApp
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private string _currentQuestionText;
        private string[] _currentOptions;
        private string _feedback;
        private int _currentIndex = -1;
        private int _score = 0;
        private readonly Question[] _questions;

        public string CurrentQuestionText
        {
            get => _currentQuestionText;
            set { _currentQuestionText = value; OnPropertyChanged(); }
        }

        public string[] CurrentOptions
        {
            get => _currentOptions;
            set { _currentOptions = value; OnPropertyChanged(); }
        }

        public string Feedback
        {
            get => _feedback;
            set { _feedback = value; OnPropertyChanged(); }
        }

        public int Score => _score;
        public int TotalQuestions => 10;
        public bool HasMoreQuestions => _currentIndex < _questions.Length - 1;

        public QuizViewModel()
        {
            _questions = new Question[]
            {
                new Question("Phishing is a type of cyber attack.", new[] { "True", "False" }, "True", "Phishing involves tricking users into providing sensitive data."),
                new Question("Encryption protects data confidentiality.", new[] { "True", "False" }, "True", "Encryption scrambles data to prevent unauthorized access."),
                new Question("A strong password should be at least 8 characters.", new[] { "True", "False" }, "True", "Longer passwords are harder to crack."),
                new Question("Malware can only spread via email.", new[] { "True", "False" }, "False", "Malware can spread via websites, USBs, etc."),
                new Question("Two-factor authentication adds security.", new[] { "True", "False" }, "True", "2FA requires a second verification step."),
                new Question("Public Wi-Fi is always secure.", new[] { "True", "False" }, "False", "Public Wi-Fi can be intercepted without protection."),
                new Question("A firewall prevents all attacks.", new[] { "True", "False" }, "False", "Firewalls reduce but don’t eliminate risks."),
                new Question("Phishing emails always contain attachments.", new[] { "True", "False" }, "False", "Phishing can use links or text."),
                new Question("Updating software fixes all vulnerabilities.", new[] { "True", "False" }, "False", "Updates help but don’t guarantee security."),
                new Question("Social engineering targets human behavior.", new[] { "True", "False" }, "True", "Social engineering exploits trust.")
            };
        }

        public void LoadNextQuestion()
        {
            _currentIndex++;
            if (_currentIndex < _questions.Length)
            {
                CurrentQuestionText = _questions[_currentIndex].Text;
                CurrentOptions = _questions[_currentIndex].Options;
                Feedback = "";
            }
        }

        public void SubmitAnswer(string answer)
        {
            if (_currentIndex >= 0 && _currentIndex < _questions.Length)
            {
                if (answer == _questions[_currentIndex].CorrectAnswer)
                {
                    _score++;
                    Feedback = "Correct! " + _questions[_currentIndex].Explanation;
                }
                else
                {
                    Feedback = "Incorrect. " + _questions[_currentIndex].Explanation;
                }
            }
        }

        public string GetScoreDescription()
        {
            double percentage = (double)_score / TotalQuestions * 100;
            if (percentage >= 80) return "Excellent! You are well-versed in cybersecurity.";
            if (percentage >= 60) return "Good job! Some improvement needed.";
            return "Needs work. Consider reviewing cybersecurity basics.";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}