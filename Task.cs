using System;

namespace CybersecurityApp
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Reminder { get; set; }
        public bool IsCompleted { get; set; }
    }
}