
using Presentation.WPF.Commands.Callbcks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class CourseListDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class AddStudentCourseListDesignViewModel : AddStudentCourseListViewModel
    {

        #region constructor
        public AddStudentCourseListDesignViewModel() {
            CourseListItems = new ObservableCollection<AddStudentCourseListItemViewModel> {
                new AddStudentCourseListItemViewModel{
                    SectionId = 23,
                    CourseCode = "IAS2233",
                    Name = "Information System",
                    LecturerName = "Monibur Rahman",
                    IsSelected = false
                    },
                new AddStudentCourseListItemViewModel{
                    SectionId = 24,
                    CourseCode = "IAS2333",
                    Name = "Software Engineering",
                    LecturerName = "Rocky Hasan",
                    IsSelected = false
                    },
                new AddStudentCourseListItemViewModel{
                    SectionId = 27,
                    CourseCode = "IAS5464",
                    Name = "Project Management",
                    LecturerName = "Dr. Haslinda",
                    IsSelected = false
                    }
            };

           // SelectCourse = new RelayCommand(AddCourseToList, CanAddToCourse);
        }
        #endregion
    }
}