using System;
using CybersecurityChatbot;

namespace CybersecurityApp
{
    public class ChatbotViewModel
    {
        // View model class managing core application data and logic
        public TaskManager TaskManager { get; } = new TaskManager(); // Manages task-related data
        public QuizManager QuizManager { get; } = new QuizManager(); // Manages quiz-related data
        public ActivityLog ActivityLog { get; } = new ActivityLog(); // Manages activity logging
        private readonly StartChat _chatSession; // Manages the chatbot session

        public ChatbotViewModel()
        {
            _chatSession = new StartChat(); // Initializes the chatbot session
        }

        public string ProcessInput(string input)
        {
            // Processes user input and logs the action
            ActivityLog.LogAction($"User input: {input}"); // Logs the input action
            return _chatSession.InitiateChatStep(input); // Delegates to StartChat for response
        }
    }

    public class TaskManager
    {
        // Manages task items and operations
        public List<TaskItem> Tasks { get; } = new List<TaskItem>(); // List of task items

        public void AddTask(string title, string description, DateTime reminder)
        {
            // Adds a new task with the given details
            Tasks.Add(new TaskItem { Title = title, Description = description, Reminder = reminder });
        }

        public void DeleteTask(int index) => Tasks.RemoveAt(index); // Removes a task by index
        public void CompleteTask(int index) => Tasks[index].IsCompleted = true; // Marks a task as completed
    }

    public class TaskItem
    {
        // Represents a single task item
        public string Title { get; set; } // Task title
        public string Description { get; set; } // Task description
        public DateTime? Reminder { get; set; } // Optional reminder date
        public bool IsCompleted { get; set; } // Completion status
    }

    public class QuizManager
    {
        // Manages quiz questions and scoring
        public List<Question> Questions { get; } = new List<Question>
        {
            // Predefined list of quiz questions with options, answers, and feedback
            new Question("Phishing emails often ask for passwords.", new[] { "True", "False" }, "True", "Phishing emails may trick you into revealing sensitive info."),
            new Question("Strong passwords should include special characters.", new[] { "True", "False" }, "True", "Special characters enhance password security."),
            // Additional questions as defined previously
        };
        public int Score { get; private set; } // Current quiz score
        public int TotalQuestions => Questions.Count; // Total number of questions
        public bool HasMoreQuestions => currentQuestionIndex < Questions.Count - 1; // Checks if more questions remain
        private int currentQuestionIndex = -1; // Tracks the current question index

        public int GetNextQuestion()
        {
            // Advances to the next question and resets score
            if (currentQuestionIndex + 1 < Questions.Count) currentQuestionIndex++;
            Score = 0;
            return currentQuestionIndex;
        }

        public string SubmitAnswer(int index, string answer)
        {
            // Evaluates the answer and returns feedback
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
        // Represents a single quiz question
        public string Text { get; } // Question text
        public string[] Options { get; } // Answer options
        public string CorrectAnswer { get; } // Correct answer
        public string Feedback { get; } // Feedback for the answer

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
        // Manages logging of user activities
        private List<LogEntry> _logs = new List<LogEntry>(); // List of log entries

        public void LogAction(string description)
        {
            // Adds a new log entry with the current timestamp
            _logs.Add(new LogEntry { Timestamp = DateTime.Now, Description = description });
        }

        public List<LogEntry> GetRecentLogs(int count) => _logs.Skip(Math.Max(0, _logs.Count - count)).Take(count).ToList();
        // Retrieves the most recent 'count' log entries
        public List<LogEntry> GetAllLogs() => new List<LogEntry>(_logs); // Returns all log entries
    }

    public class LogEntry
    {
        // Represents a single log entry
        public DateTime Timestamp { get; set; } // Timestamp of the log
        public string Description { get; set; } // Description of the logged action
    }
}