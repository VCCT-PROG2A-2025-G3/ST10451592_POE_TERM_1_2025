using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CybersecurityApp
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private List<Question> _questions;
        private int _currentQuestionIndex;
        private int _score;
        private string _feedback;

        public Question CurrentQuestion => _questions[_currentQuestionIndex];
        public int Score
        {
            get => _score;
            set { _score = value; OnPropertyChanged(); }
        }
        public string Feedback
        {
            get => _feedback;
            set { _feedback = value; OnPropertyChanged(); }
        }
        public bool IsQuizComplete => _currentQuestionIndex >= _questions.Count;

        public ICommand AnswerCommand { get; }

        public QuizViewModel()
        {
            _questions = new List<Question>
            {
                new Question { Text = "Phishing emails often ask for personal information. True/False", Options = new[] { "True", "False" }, CorrectAnswerIndex = 0, Explanation = "Always verify the sender.", IsTrueFalse = true },
                new Question { Text = "What is a common sign of a phishing attempt?", Options = new[] { "Urgent language", "Friendly greeting", "Company logo" }, CorrectAnswerIndex = 0, Explanation = "Urgency is a red flag." }
            };
            _currentQuestionIndex = 0;
            _score = 0;
            Feedback = "";
            AnswerCommand = new RelayCommand(CheckAnswer);
        }

        private void CheckAnswer(object parameter)
        {
            if (parameter is string selectedAnswer)
            {
                int selectedIndex = Array.IndexOf(CurrentQuestion.Options, selectedAnswer);
                if (selectedIndex == CurrentQuestion.CorrectAnswerIndex)
                {
                    Score++;
                    Feedback = "Correct! " + CurrentQuestion.Explanation;
                }
                else
                {
                    Feedback = $"Incorrect. {CurrentQuestion.Explanation}";
                }
                _currentQuestionIndex++;
                OnPropertyChanged(nameof(CurrentQuestion));
                OnPropertyChanged(nameof(IsQuizComplete));
                if (IsQuizComplete)
                {
                    Feedback = $"Quiz Complete! Your score: {Score}/{_questions.Count}";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}