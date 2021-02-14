
using Presentation.WPF.Commands.Callbcks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class StudentOfferedCourseListViewModel
    /// Write your documentation here
    /// </summary>
    public class StudentOfferedCourseListViewModel
    {

        public ObservableCollection<StudentOfferedCourseListItemViewModel> Items { get; set; } 
            = new ObservableCollection<StudentOfferedCourseListItemViewModel>();

        public StudentOfferedCourseListItemViewModel SelectdOfferedCourseListItemViewModel { get; set; }
        public ICommand ItemSelected { get; set; }


        public StudentOfferedCourseListViewModel()
        {
            //Items = new ObservableCollection<StudentOfferedCourseListItemViewModel>();
            //// RemoveItem = new RelayACommand(it => ClickedRecived(it));
            //Items = new ObservableCollection<StudentOfferedCourseListItemViewModel> {
            //    new StudentOfferedCourseListItemViewModel{
            //        SectionId=34,
            //        CourseId=3,
            //        CourseName="Information System",
            //        LecturerName ="Latifah Abdul Latif",
            //        IsSelected = false,
            //    },
            //    new StudentOfferedCourseListItemViewModel{
            //        SectionId=34,
            //        CourseId=3,
            //        CourseName="Project Management",
            //        LecturerName ="Dr Haslinda",
            //        IsSelected = false,
            //    },
            //};
            ItemSelected = new RelayCommand(ItemRemovedOrSelect, CanDelete);
        }

        //private void ClickedRecived(object obj)
        //{
        //    Console.WriteLine("This item clicked " + SectionId);
        //    IsRemove = true;
        //}

        private bool CanDelete(object obj)
        {
            return SelectdOfferedCourseListItemViewModel != null;
        }

        private void ItemRemovedOrSelect(object obj)
        {
            //SelectdOfferedCourseListItemViewModel = (StudentOfferedCourseListItemViewModel)obj;
            //MessageBox.Show(_selectdOfferedCourseListItemViewModel.CourseName + "Item Remove", "Check");
            // MessageBox.Show("Can not Remove "+ SelectdOfferedCourseListItemViewModel.ToString(), "Check");
            MessageBox.Show(SelectdOfferedCourseListItemViewModel.CourseName + " Course", "Selected Course");
            Items.Remove(SelectdOfferedCourseListItemViewModel);
            SelectdOfferedCourseListItemViewModel = null;

        }

        public void AddCourse(StudentOfferedCourseListItemViewModel item)
        {
            Items.Add(item);
            //MessageBox.Show(item.CourseName + " Course", "Selected Course");
        }

        public void RemoveCourse(StudentOfferedCourseListItemViewModel item)
        {
            Items.Remove(item);
        }
    }
}