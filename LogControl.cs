using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class LogControl : UserControl
    {
        private readonly ActivityLog _activityLog;

        public LogControl(ActivityLog activityLog)
        {
            InitializeComponent();
            _activityLog = activityLog;
            UpdateLogDisplay();
            showMoreButton.Click += ShowMoreButton_Click;
        }

        private void UpdateLogDisplay()
        {
            logListBox.Items.Clear();
            var recentLogs = _activityLog.GetRecentLogs(10);
            foreach (var log in recentLogs)
            {
                logListBox.Items.Add($"{log.Timestamp:yyyy-MM-dd HH:mm:ss} - {log.Description}");
            }
        }

        private void ShowMoreButton_Click(object sender, EventArgs e)
        {
            var allLogs = _activityLog.GetAllLogs();
            string logDetails = string.Join(Environment.NewLine, allLogs.Select(l => $"{l.Timestamp:yyyy-MM-dd HH:mm:ss} - {l.Description}"));
            MessageBox.Show(logDetails, "Full Activity Log");
        }
    }
}