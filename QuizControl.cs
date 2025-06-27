using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class QuizControl : UserControl
    {
        private readonly QuizViewModel _viewModel;

        public QuizControl(QuizViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindControls();
            LoadNextQuestion();
        }

        private void BindControls()
        {
            questionLabel.DataBindings.Add("Text", _viewModel, "CurrentQuestionText", false, DataSourceUpdateMode.OnPropertyChanged);
            feedbackLabel.DataBindings.Add("Text", _viewModel, "Feedback", false, DataSourceUpdateMode.OnPropertyChanged);
            submitButton.Click += (s, e) => SubmitAnswer();
        }

        private void LoadNextQuestion()
        {
            _viewModel.LoadNextQuestion();
            if (_viewModel.CurrentOptions != null)
            {
                option1RadioButton.Text = _viewModel.CurrentOptions.Length > 0 ? _viewModel.CurrentOptions[0] : "";
                option2RadioButton.Text = _viewModel.CurrentOptions.Length > 1 ? _viewModel.CurrentOptions[1] : "";
                option3RadioButton.Text = _viewModel.CurrentOptions.Length > 2 ? _viewModel.CurrentOptions[2] : "";
            }
            option1RadioButton.Checked = false;
            option2RadioButton.Checked = false;
            option3RadioButton.Checked = false;
        }

        private void SubmitAnswer()
        {
            string selectedAnswer = "";
            if (option1RadioButton.Checked) selectedAnswer = option1RadioButton.Text;
            else if (option2RadioButton.Checked) selectedAnswer = option2RadioButton.Text;
            else if (option3RadioButton.Checked) selectedAnswer = option3RadioButton.Text;

            _viewModel.SubmitAnswer(selectedAnswer);
            if (_viewModel.HasMoreQuestions)
            {
                LoadNextQuestion();
            }
            else
            {
                MessageBox.Show($"Quiz Complete! Score: {_viewModel.Score}/{_viewModel.TotalQuestions}\nDescription: {_viewModel.GetScoreDescription()}");
            }
        }
    }
}