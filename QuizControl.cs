using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class QuizControl : UserControl
    {
        private readonly QuizViewModel _viewModel;

        public QuizControl()
        {
            InitializeComponent();
            _viewModel = new QuizViewModel();
            BindControls();
        }

        private void BindControls()
        {
            lblQuestion.DataBindings.Add("Text", _viewModel, "CurrentQuestion.Text", false, DataSourceUpdateMode.OnPropertyChanged);
            lblFeedback.DataBindings.Add("Text", _viewModel, "Feedback", false, DataSourceUpdateMode.OnPropertyChanged);
            optA.DataBindings.Add("Text", _viewModel, "CurrentQuestion.Options[0]", false, DataSourceUpdateMode.OnPropertyChanged);
            optB.DataBindings.Add("Text", _viewModel, "CurrentQuestion.Options[1]", false, DataSourceUpdateMode.OnPropertyChanged);
            optC.DataBindings.Add("Text", _viewModel, "CurrentQuestion.Options[2]", false, DataSourceUpdateMode.OnPropertyChanged, "");
            btnSubmit.Click += (s, e) => SubmitAnswer();
        }

        private void SubmitAnswer()
        {
            if (optA.Checked) _viewModel.AnswerCommand.Execute(optA.Text);
            else if (optB.Checked) _viewModel.AnswerCommand.Execute(optB.Text);
            else if (optC.Checked) _viewModel.AnswerCommand.Execute(optC.Text);
            optA.Checked = optB.Checked = optC.Checked = false;
        }
    }
}