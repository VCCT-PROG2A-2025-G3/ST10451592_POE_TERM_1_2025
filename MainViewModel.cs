using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CybersecurityApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ChatViewModel ChatViewModel { get; }
        public TaskViewModel TaskViewModel { get; }
        public QuizViewModel QuizViewModel { get; }
        public ActivityLogViewModel LogViewModel { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            ChatViewModel = new ChatViewModel();
            TaskViewModel = new TaskViewModel();
            QuizViewModel = new QuizViewModel();
            LogViewModel = new ActivityLogViewModel();
        }
    }
}