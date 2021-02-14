
using Presentation.WPF.Commands.Callbcks;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class CourseListDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class AddLecturerCourseListDesignViewModel : AddLecturerCourseListViewModel
    {
        public static AddLecturerCourseListDesignViewModel Instance => new AddLecturerCourseListDesignViewModel();

        public AddLecturerCourseListItemViewModel SelectedCourseItem { get; set; }

        public ICommand SelectCourse { get; set; }

        #region constructor
        public AddLecturerCourseListDesignViewModel() {
            CourseListItems = new List<AddLecturerCourseListItemViewModel> {
                new AddLecturerCourseListItemViewModel{
                    CourseId = 23,
                    CourseCode = "IAS2233",
                    Name = "Information System",
                    IsSelected = false
                    },
                new AddLecturerCourseListItemViewModel{
                    CourseId = 24,
                    CourseCode = "IAS2333",
                    Name = "Software Engineering",
                    IsSelected = false
                    },
                new AddLecturerCourseListItemViewModel{
                    CourseId = 27,
                    CourseCode = "IAS5464",
                    Name = "Project Management",
                    IsSelected = false
                    }
            };
            SelectCourse = new RelayCommand(AddCourseToList, CanAddToCourse);
        }
        #endregion

        public bool CanAddToCourse(object obj)
        {
            return SelectedCourseItem != null;
        }

        public void AddCourseToList(object obj)
        {
            MessageBox.Show(SelectedCourseItem.Name + " Course", "Selected Course");
        }
    }
}