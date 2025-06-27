using System;
using CybersecurityChatbot;

namespace CybersecurityApp
{
    public class ChatbotViewModel
    {
        public TaskManager TaskManager { get; } = new TaskManager();
        public QuizManager QuizManager { get; } = new QuizManager();
        public ActivityLog ActivityLog { get; } = new ActivityLog();

        private readonly StartChat _chatSession; // Manages the chatbot session

        public ChatbotViewModel()
        {
            _chatSession = new StartChat(); // Initializes the chatbot session
        }

        public string ProcessInput(string input)
        {
            ActivityLog.LogAction($"User input: {input}"); // Logs the input action
            return _chatSession.InitiateChatStep(input); // Delegates to StartChat for response
        }
    }

    public class TaskManager
    {
        public List<TaskItem> Tasks { get; } = new List<TaskItem>();

        public void AddTask(string title, string description, DateTime reminder)
        {
            Tasks.Add(new TaskItem { Title = title, Description = description, Reminder = reminder });
        }

        public void DeleteTask(int index) => Tasks.RemoveAt(index);
        public void CompleteTask(int index) => Tasks[index].IsCompleted = true;
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Reminder { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class QuizManager
    {
        public List<Question> Questions { get; } = new List<Question>
        {
            new Question("Phishing emails often ask for passwords.", new[] { "True", "False" }, "True", "Phishing emails may trick you into revealing sensitive info."),
            new Question("Strong passwords should include special characters.", new[] { "True", "False" }, "True", "Special characters enhance password security."),
            new Question("It’s safe to click links in unsolicited emails.", new[] { "True", "False" }, "False", "Unsolicited links can lead to phishing sites."),
            new Question("Two-factor authentication adds extra security.", new[] { "True", "False" }, "True", "Two-factor authentication protects against unauthorized access."),
            new Question("Public Wi-Fi is always secure for banking.", new[] { "True", "False" }, "False", "Public Wi-Fi can be intercepted; use a VPN."),
            new Question("Updating software removes all security risks.", new[] { "True", "False" }, "False", "Updates reduce risks but don’t eliminate them."),
            new Question("You should share your password with friends.", new[] { "True", "False" }, "False", "Never share passwords with anyone."),
            new Question("Malware can infect your device via email attachments.", new[] { "True", "False" }, "True", "Avoid opening unknown attachments."),
            new Question("Backing up data is unnecessary if you use cloud storage.", new[] { "True", "False" }, "False", "Regular backups are essential for data recovery."),
            new Question("A strong password should be at least 12 characters long.", new[] { "True", "False" }, "True", "Longer passwords are harder to crack.")
        };
        public int Score { get; private set; }
        public int TotalQuestions => Questions.Count;
        public bool HasMoreQuestions => currentQuestionIndex < Questions.Count - 1;
        private int currentQuestionIndex = -1;

        public int GetNextQuestion()
        {
            if (currentQuestionIndex + 1 < Questions.Count) currentQuestionIndex++;
            Score = 0;
            return currentQuestionIndex;
        }

        public string SubmitAnswer(int index, string answer)
        {
            if (Questions[index].CorrectAnswer == answer)
            {
                Score++;
                return $"{Questions[index].Feedback} Correct!";
            }
            return $"{Questions[index].Feedback} Incorrect. The correct answer is {Questions[index].CorrectAnswer}.";
        }

        public string GetScoreDescription() => Score > 7 ? "Great job! You're a cybersecurity pro!" : "Keep learning to stay safe online!";
    }

    public class Question
    {
        public string Text { get; }
        public string[] Options { get; }
        public string CorrectAnswer { get; }
        public string Feedback { get; }

        public Question(string text, string[] options, string correctAnswer, string feedback)
        {
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
            Feedback = feedback;
        }
    }

    public class ActivityLog
    {
        private List<LogEntry> _logs = new List<LogEntry>();

        public void LogAction(string description)
        {
            _logs.Add(new LogEntry { Timestamp = DateTime.Now, Description = description });
        }

        public List<LogEntry> GetRecentLogs(int count) => _logs.Skip(Math.Max(0, _logs.Count - count)).Take(count).ToList();
        public List<LogEntry> GetAllLogs() => new List<LogEntry>(_logs);
    }

    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
    }
}