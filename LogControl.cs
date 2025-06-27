using System;
using System.Windows.Forms;
using System.Linq;

namespace CybersecurityApp
{
    public partial class LogControl : UserControl
    {
        private readonly ActivityLog _activityLog;

        public LogControl(ActivityLog activityLog)
        {
            InitializeComponent();
            _activityLog = activityLog ?? throw new ArgumentNullException(nameof(activityLog));
            PopulateLog();
        }

        private void PopulateLog()
        {
            // Assuming a ListBox named logListBox (add this in Designer if not present)
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