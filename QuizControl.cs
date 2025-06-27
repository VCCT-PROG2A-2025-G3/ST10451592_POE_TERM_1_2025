using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class QuizControl : UserControl
    {
        private readonly QuizManager _quizManager;
        private int currentQuestionIndex = -1;

        public QuizControl(QuizManager quizManager)
        {
            InitializeComponent();
            _quizManager = quizManager;
            LoadNextQuestion();
            submitButton.Click += SubmitButton_Click;
        }

        private void LoadNextQuestion()
        {
            currentQuestionIndex = _quizManager.GetNextQuestion();
            if (currentQuestionIndex >= 0)
            {
                var question = _quizManager.Questions[currentQuestionIndex];
                questionLabel.Text = question.Text;
                option1RadioButton.Text = question.Options[0];
                option2RadioButton.Text = question.Options.Length > 1 ? question.Options[1] : "";
                option3RadioButton.Text = question.Options.Length > 2 ? question.Options[2] : "";
                option1RadioButton.Checked = false;
                option2RadioButton.Checked = false;
                option3RadioButton.Checked = false;
                feedbackLabel.Text = "";
            }
            else
            {
                ShowResults();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex >= 0)
            {
                string selectedAnswer = option1RadioButton.Checked ? option1RadioButton.Text :
                    option2RadioButton.Checked ? option2RadioButton.Text :
                    option3RadioButton.Checked ? option3RadioButton.Text : "";
                string feedback = _quizManager.SubmitAnswer(currentQuestionIndex, selectedAnswer);
                feedbackLabel.Text = feedback;
                if (!_quizManager.HasMoreQuestions)
                {
                    ShowResults();
                }
            }
        }

        private void ShowResults()
        {
            string result = $"Quiz Complete! Score: {_quizManager.Score}/{_quizManager.TotalQuestions}\n{_quizManager.GetScoreDescription()}";
            MessageBox.Show(result);
            LoadNextQuestion();
        }
    }
}