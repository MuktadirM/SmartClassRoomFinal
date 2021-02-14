
using Presentation.WPF.Commands.Callbcks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class StudentOfferedCourseListDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class StudentOfferedCourseListDesignViewModel : StudentOfferedCourseListViewModel
    {
        public static StudentOfferedCourseListDesignViewModel Instance => new StudentOfferedCourseListDesignViewModel();


        #region constructor
        public StudentOfferedCourseListDesignViewModel()
        {
            ItemSelected = new RelayCommand(ItemRemovedOrSelect, CanDelete);
        }
        #endregion


        private bool CanDelete(object obj) {
            return SelectdOfferedCourseListItemViewModel != null;
        }

        private void ItemRemovedOrSelect(object obj) {
            SelectdOfferedCourseListItemViewModel = (StudentOfferedCourseListItemViewModel)obj;
            //MessageBox.Show(_selectdOfferedCourseListItemViewModel.CourseName + "Item Remove", "Check");
           // MessageBox.Show("Can not Remove "+ SelectdOfferedCourseListItemViewModel.ToString(), "Check");
            Items.Remove(SelectdOfferedCourseListItemViewModel);
            SelectdOfferedCourseListItemViewModel = null;
            
        }

    }
}