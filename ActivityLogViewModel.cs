using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CybersecurityApp
{
    public class ActivityLogViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<LogEntry> _logEntries = new ObservableCollection<LogEntry>();
        private int _currentOffset;

        public ObservableCollection<LogEntry> LogEntries => new ObservableCollection<LogEntry>(_logEntries.Skip(_currentOffset).Take(5));

        public void AddEntry(string description)
        {
            _logEntries.Insert(0, new LogEntry { Description = description, Timestamp = DateTime.Now });
            if (_logEntries.Count > 10) _logEntries.RemoveAt(_logEntries.Count - 1);
            OnPropertyChanged(nameof(LogEntries));
        }

        public void ShowMore()
        {
            _currentOffset += 5;
            if (_currentOffset >= _logEntries.Count) _currentOffset = 0;
            OnPropertyChanged(nameof(LogEntries));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class LogEntry
    {
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}