
using Presentation.Admin.ViewModels;

namespace Presentation.WPF.Commands.Callbcks
{
    /// <summary>
    /// Class IClickedItem
    /// Write your documentation here
    /// </summary>
    public interface IClickedItem
    {
        public void ClickedItem<T>(T item);
    }
}