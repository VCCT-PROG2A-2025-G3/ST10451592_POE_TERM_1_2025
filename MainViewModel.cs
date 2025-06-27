using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CybersecurityApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        private readonly ChatViewModel _chatViewModel;
        private readonly TaskViewModel _taskViewModel;
        private readonly QuizViewModel _quizViewModel;
        private readonly ActivityLogViewModel _logViewModel;

        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand NavigateCommand { get; }

        public MainViewModel()
        {
            _chatViewModel = new ChatViewModel();
            _taskViewModel = new TaskViewModel();
            _quizViewModel = new QuizViewModel();
            _logViewModel = new ActivityLogViewModel();
            CurrentView = _chatViewModel;

            NavigateCommand = new RelayCommand(Navigate);
        }

        private void Navigate(object parameter)
        {
            switch (parameter?.ToString())
            {
                case "Chat": CurrentView = _chatViewModel; break;
                case "Tasks": CurrentView = _taskViewModel; break;
                case "Quiz": CurrentView = _quizViewModel; break;
                case "Log": CurrentView = _logViewModel; break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}