
using Presentation.ViewModels;
using Presentation.WPF.Commands.Callbcks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class CourseListViewModel
    /// Write your documentation here
    /// </summary>
    public class AddStudentCourseListViewModel : BaseViewModel
    {
        /// <summary>
        /// All avaiable courses
        /// </summary>
        public ObservableCollection<AddStudentCourseListItemViewModel> CourseListItems { get; set; }

        /// <summary>
        /// The selected course from combo box item ready to add
        /// </summary>
        public AddStudentCourseListItemViewModel SelectedCourseItem { get; set; }

        public StudentOfferedCourseListViewModel StudentOfferedCourseListView;

        /// <summary>
        /// The Added Courses for single student
        /// </summary>
        public ObservableCollection<StudentOfferedCourseListItemViewModel> SelectedCourseList { get; set; } =
            new ObservableCollection<StudentOfferedCourseListItemViewModel>();

        /// <summary>
        /// Selected course action
        /// </summary>
        public ICommand SelectCourse { get; set; }

        #region constructor
        public AddStudentCourseListViewModel()
        {
            this.CourseListItems = CourseListItems;


            SelectCourse = new RelayCommand(AddCourseToList, CanAddToCourse);
            StudentOfferedCourseListView.Items = SelectedCourseList;
        }
        #endregion

        public bool CanAddToCourse(object obj)
        {
            return SelectedCourseItem != null;
        }

        public void AddCourseToList(object obj)
        {
            var item = SelectedCourseItem;
            var item2 = new StudentOfferedCourseListItemViewModel
            {
                SectionId = item.SectionId,
                CourseName = item.Name,
                LecturerName = item.LecturerName,
            };
            SelectedCourseList.Add(item2);
            StudentOfferedCourseListView.Items = SelectedCourseList;
            OnPropertyChanged(nameof(StudentOfferedCourseListView));

            MessageBox.Show(SelectedCourseItem.Name + " Course" + SelectedCourseList.Count, "Selected Course");

        }



    }
}