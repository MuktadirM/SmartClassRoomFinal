using System.ComponentModel;

namespace Presentation.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual void Dispose() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
