using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityApp
{
    public class RespondToUser
    {
        private readonly UserMemory _memory;
        private readonly Random _random;
        private readonly Dictionary<string, List<string>> _keywordResponses;
        private readonly Dictionary<string, Action<string>> _intents;
        private readonly TaskViewModel _taskViewModel;
        private readonly QuizViewModel _quizViewModel;

        public RespondToUser(UserMemory memory, TaskViewModel taskViewModel, QuizViewModel quizViewModel)
        {
            _memory = memory;
            _random = new Random();
            _taskViewModel = taskViewModel;
            _quizViewModel = quizViewModel;
            _keywordResponses = new Dictionary<string, List<string>>
            {
                { "hello", new List<string> { "Hi there!", "Hello!" } },
                { "help", new List<string> { "How can I assist you?", "Need help?" } }
            };
            _intents = new Dictionary<string, Action<string>>
            {
                { "add task", AddTaskFromInput },
                { "set reminder", SetReminderFromInput },
                { "start quiz", _ => StartQuiz() }
            };
        }

        public string ProcessInput(string input)
        {
            input = input?.Trim().ToLower() ?? string.Empty;
            _memory.AddToHistory(input);

            foreach (var intent in _intents)
            {
                if (input.Contains(intent.Key))
                {
                    intent.Value(input);
                    return $"Handled intent: {intent.Key}";
                }
            }

            foreach (var keyword in _keywordResponses)
            {
                if (input.Contains(keyword.Key))
                {
                    return keyword.Value[_random.Next(keyword.Value.Count)];
                }
            }

            return "I'm not sure how to respond to that.";
        }

        private void AddTaskFromInput(string input)
        {
            var task = new Task { Title = input.Replace("add task", "").Trim(), Description = "Added via chat", Reminder = DateTime.Now.AddHours(1) };
            _taskViewModel.Tasks.Add(task);
        }

        private void SetReminderFromInput(string input)
        {
            var task = _taskViewModel.Tasks.LastOrDefault();
            if (task != null)
            {
                task.Reminder = DateTime.Now.AddHours(2);
            }
        }

        private void StartQuiz()
        {
            // Navigation handled by tab switch
        }
    }
}