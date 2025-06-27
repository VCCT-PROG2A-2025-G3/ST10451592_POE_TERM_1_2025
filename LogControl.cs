using System;
using System.Windows.Forms;
using System.Linq;

namespace CybersecurityApp
{
    public partial class LogControl : UserControl
    {
        // User control for displaying activity logs
        private readonly ActivityLog _activityLog; // Manages log data

        public LogControl(ActivityLog activityLog)
        {
            InitializeComponent(); // Initializes GUI components from the designer
            _activityLog = activityLog ?? throw new ArgumentNullException(nameof(activityLog)); // Sets log instance
            PopulateLog(); // Populates the log display on initialization
        }

        private void PopulateLog()
        {
            // Populates the log list with all logged entries, sorted by timestamp
            if (logListBox == null)
            {
                logListBox = new ListBox
                {
                    Location = new System.Drawing.Point(10, 10),
                    Size = new System.Drawing.Size(750, 400),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
                };
                Controls.Add(logListBox);
            }
            logListBox.Items.Clear();
            var logs = _activityLog.GetAllLogs();
            foreach (var log in logs.OrderByDescending(l => l.Timestamp))
            {
                logListBox.Items.Add($"{log.Timestamp:yyyy-MM-dd HH:mm:ss} - {log.Description}");
            }
        }
    }
}