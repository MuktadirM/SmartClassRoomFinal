
using System.Collections.ObjectModel;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class LecturerSelectedCourseListViewModel
    /// Write your documentation here
    /// </summary>
    public class LecturerSelectedCourseListViewModel
    {
        public ObservableCollection<LecturerSelectedCourseListItemViewModel> Items { get; set; } = 
            new ObservableCollection<LecturerSelectedCourseListItemViewModel>();
        public LecturerSelectedCourseListViewModel() {
            Items = new ObservableCollection<LecturerSelectedCourseListItemViewModel> { 
                new LecturerSelectedCourseListItemViewModel{ 
                    CourseId=12,
                    CourseCode="IAS5656",
                    Name = "Computer Organaization",
                    IsSelected =false
                },
            };
        }
        #region constructor

        #endregion
    }
}