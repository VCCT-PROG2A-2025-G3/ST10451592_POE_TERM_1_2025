using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class MainForm : Form
    {
        private readonly MainViewModel _viewModel;

        public MainForm()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            UpdateView();
        }

        private void TabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabChat":
                    tabChat.Controls.Clear();
                    tabChat.Controls.Add(new ChatControl(_viewModel.ChatViewModel));
                    break;
                case "tabTasks":
                    tabTasks.Controls.Clear();
                    tabTasks.Controls.Add(new TaskControl(_viewModel.TaskViewModel));
                    break;
                case "tabQuiz":
                    tabQuiz.Controls.Clear();
                    tabQuiz.Controls.Add(new QuizControl(_viewModel.QuizViewModel));
                    break;
                case "tabLog":
                    tabLog.Controls.Clear();
                    tabLog.Controls.Add(new LogControl(_viewModel.LogViewModel));
                    break;
            }
        }
    }
}