
using Presentation.ViewModels;

namespace Presentation.WPF.ViewModels
{
    /// <summary>
    /// Class MessageViewModel
    /// Write your documentation here
    /// </summary>
    public class MessageViewModel : BaseViewModel
    {
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public bool HasMessage => !string.IsNullOrEmpty(Message);
    }
}