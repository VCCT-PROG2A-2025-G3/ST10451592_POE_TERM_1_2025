using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CybersecurityApp
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddTask(object parameter)
        {
            if (parameter is Task task && !string.IsNullOrWhiteSpace(task.Title))
            {
                Tasks.Add(task);
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public void CompleteTask(object parameter)
        {
            if (Tasks.Count > 0)
            {
                Tasks[0].IsCompleted = true;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public void DeleteTask(object parameter)
        {
            if (Tasks.Count > 0)
            {
                Tasks.RemoveAt(0);
                OnPropertyChanged(nameof(Tasks));
            }
        }
    }
}