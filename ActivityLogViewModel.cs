using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CybersecurityApp
{
    public class ActivityLogViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ActivityLogEntry> _logEntries = new ObservableCollection<ActivityLogEntry>();

        public ObservableCollection<ActivityLogEntry> LogEntries
        {
            get => _logEntries;
            set { _logEntries = value; OnPropertyChanged(); }
        }

        public ActivityLogViewModel()
        {
            AddLogEntry("Application started.");
        }

        public void AddLogEntry(string description)
        {
            LogEntries.Add(new ActivityLogEntry { Timestamp = DateTime.Now, Description = description });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}