using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class MainForm : Form
    {
        // Main form class managing the tabbed interface and initialization
        private readonly ChatbotViewModel _viewModel; // View model instance for data and logic

        public MainForm()
        {
            InitializeComponent(); // Initializes GUI components from the designer
            _viewModel = new ChatbotViewModel(); // Creates a new view model instance
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged; // Event handler for tab changes
            PlayGreeting(); // Plays the embedded voice greeting on startup
            UpdateView(); // Updates all tab controls on form load
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Updates the content of the selected tab when changed
            UpdateView();
        }

        private void UpdateView()
        {
            // Clears and reinitializes controls for each tab based on the view model
            tabChat.Controls.Clear();
            tabChat.Controls.Add(new ChatControl(_viewModel)); // Adds ChatControl instance
            tabTasks.Controls.Clear();
            tabTasks.Controls.Add(new TaskControl(_viewModel.TaskManager)); // Adds TaskControl instance
            tabQuiz.Controls.Clear();
            tabQuiz.Controls.Add(new QuizControl(_viewModel.QuizManager)); // Adds QuizControl instance
            tabLog.Controls.Clear();
            tabLog.Controls.Add(new LogControl(_viewModel.ActivityLog)); // Adds LogControl instance
        }

        private void PlayGreeting()
        {
            // Plays the embedded greeting WAV file on application start
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CybersecurityApp.greeting.wav"))
                {
                    // Retrieves the embedded resource stream for the WAV file
                    if (stream != null)
                    {
                        using (var player = new SoundPlayer(stream))
                        {
                            // Creates and plays the sound using SoundPlayer
                            player.Play();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handles any errors during playback and displays a message
                MessageBox.Show($"Failed to play greeting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}