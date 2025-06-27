using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class MainForm : Form
    {
        private readonly ChatbotViewModel _viewModel;

        public MainForm()
        {
            InitializeComponent();
            _viewModel = new ChatbotViewModel();
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            PlayGreeting();
            UpdateView();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            tabChat.Controls.Clear();
            tabChat.Controls.Add(new ChatControl(_viewModel));
            tabTasks.Controls.Clear();
            tabTasks.Controls.Add(new TaskControl(_viewModel.TaskManager));
            tabQuiz.Controls.Clear();
            tabQuiz.Controls.Add(new QuizControl(_viewModel.QuizManager));
            tabLog.Controls.Clear();
            tabLog.Controls.Add(new LogControl(_viewModel.ActivityLog));
        }

        private void PlayGreeting()
        {
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CybersecurityApp.Greeting.resources"))
                {
                    if (stream != null)
                    {
                        using (var player = new SoundPlayer(stream))
                        {
                            player.Play(); // Plays synchronously; use PlaySync() for blocking playback
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to play greeting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}