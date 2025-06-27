namespace CybersecurityApp
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Reminder { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class Question
    {
        public string Text { get; }
        public string[] Options { get; }
        public string CorrectAnswer { get; }
        public string Explanation { get; }

        public Question(string text, string[] options, string correctAnswer, string explanation)
        {
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
            Explanation = explanation;
        }
    }
}