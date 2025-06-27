using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CybersecurityApp
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Task> _tasks = new ObservableCollection<Task>();
        public Task _selectedTask;

        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set { _tasks = value; OnPropertyChanged(); }
        }

        public Task SelectedTask
        {
            get => _selectedTask;
            set { _selectedTask = value; OnPropertyChanged(); }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand CompleteTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public TaskViewModel()
        {
            AddTaskCommand = new RelayCommand(AddTask);
            CompleteTaskCommand = new RelayCommand(CompleteTask, CanCompleteTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask, CanDeleteTask);
        }

        public void AddTask(object parameter)
        {
            var newTask = new Task { Title = "New Task", Description = "Description", Reminder = DateTime.Now.AddDays(1) };
            Tasks.Add(newTask);
        }

        public bool CanCompleteTask(object parameter) => SelectedTask != null && !SelectedTask.IsCompleted;
        public void CompleteTask(object parameter)
        {
            if (SelectedTask != null)
            {
                SelectedTask.IsCompleted = true;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public bool CanDeleteTask(object parameter) => SelectedTask != null;
        public void DeleteTask(object parameter)
        {
            if (SelectedTask != null)
            {
                Tasks.Remove(SelectedTask);
                SelectedTask = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}