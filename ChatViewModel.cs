using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CybersecurityApp
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private string _userInput;
        private string _response;
        private readonly RespondToUser _responder;
        private readonly UserMemory _memory;

        public string UserInput
        {
            get => _userInput;
            set { _userInput = value; OnPropertyChanged(); }
        }

        public string Response
        {
            get => _response;
            set { _response = value; OnPropertyChanged(); }
        }

        public ICommand SendCommand { get; }

        public ChatViewModel()
        {
            _memory = new UserMemory();
            _responder = new RespondToUser(_memory, new TaskViewModel(), new QuizViewModel());
            SendCommand = new RelayCommand(Send);
        }

        public void Send(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(UserInput))
            {
                Response = _responder.ProcessInput(UserInput);
                UserInput = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
     public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}