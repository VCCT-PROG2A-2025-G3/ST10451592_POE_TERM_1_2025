using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tabControl.SelectedIndexChanged += (s, e) => UpdateView();
            UpdateView();
        }

        private void UpdateView()
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabChat":
                    tabChat.Controls.Clear();
                    tabChat.Controls.Add(new ChatControl());
                    break;
                case "tabTasks":
                    tabTasks.Controls.Clear();
                    tabTasks.Controls.Add(new TaskControl());
                    break;
                case "tabQuiz":
                    tabQuiz.Controls.Clear();
                    tabQuiz.Controls.Add(new QuizControl());
                    break;
                case "tabLog":
                    tabLog.Controls.Clear();
                    tabLog.Controls.Add(new LogControl());
                    break;
            }
        }
    }
}