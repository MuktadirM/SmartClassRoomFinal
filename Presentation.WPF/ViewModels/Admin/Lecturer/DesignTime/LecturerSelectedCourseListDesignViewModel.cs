
using Presentation.WPF.Commands.Callbcks;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class LecturerSelectedCourseListDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class LecturerSelectedCourseListDesignViewModel : LecturerSelectedCourseListViewModel
    {
        public static LecturerSelectedCourseListDesignViewModel Instance => new LecturerSelectedCourseListDesignViewModel();

        public LecturerSelectedCourseListItemViewModel SelectdCourseListItemViewModel { get; set; }
        public ICommand ItemSelected { get; set; }

        public LecturerSelectedCourseListDesignViewModel()
        {
            ItemSelected = new RelayCommand(ItemRemovedOrSelect, CanDelete);
        }


        #region constructor
        #endregion

        private bool CanDelete(object obj)
        {
            return SelectdCourseListItemViewModel != null;
        }

        private void ItemRemovedOrSelect(object obj)
        {
            //_selectdOfferedCourseListItemViewModel = (StudentOfferedCourseListItemViewModel)obj;
            //MessageBox.Show(_selectdOfferedCourseListItemViewModel.CourseName + "Item Remove", "Check");
            //MessageBox.Show("Can not Remove", "Check");
            Items.Remove(SelectdCourseListItemViewModel);
            SelectdCourseListItemViewModel = null;
        }
    }
}