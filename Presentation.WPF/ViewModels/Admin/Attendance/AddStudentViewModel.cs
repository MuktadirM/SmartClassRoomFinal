
using Presentation.ViewModels;
using Presentation.WPF.Commands.Callbcks;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.CourseServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class AddStudentViewModel
    /// Write your documentation here
    /// </summary>
    public class AddStudentViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Matric { get; set; }
        public string Email { get; set; }
        public string Faculty { get; set; }
        public string Semester { get; set; }
        public string Phone { get; set; }



        /// <summary>
        /// All avaiable courses
        /// </summary>
        public ObservableCollection<AddStudentCourseListItemViewModel> CourseListItems { get; set; } =
            new ObservableCollection<AddStudentCourseListItemViewModel>();

        /// <summary>
        /// The Added Courses for single student
        /// </summary>
        public ObservableCollection<StudentOfferedCourseListItemViewModel> SelectedOfferedCourseItem { get; set; } = 
            new ObservableCollection<StudentOfferedCourseListItemViewModel>();

        /// <summary>
        /// Selected course from list
        /// </summary>
        public StudentOfferedCourseListItemViewModel SelectdOfferedCourseListItemViewModel { get; set; }

        /// <summary>
        /// The selected course from combo box item ready to add
        /// </summary>
        public AddStudentCourseListItemViewModel SelectedCourseItem { get; set; }

        public ICommand AddStudent { get; set; }
        public ICommand AddCourse { get; set; }

        /// <summary>
        /// Selected course action
        /// </summary>
        public ICommand ItemSelected { get; set; }

        private readonly ICourseServices _courseServices;
        private readonly IRegistrationService _registrationService;

        #region constructor
        public AddStudentViewModel(ICourseServices courseServices, IRegistrationService registrationService)
        {
            _courseServices = courseServices;
            _registrationService = registrationService;

            AddStudent = new RelayCommand(AddStudentComplete, CanSubmitStudent);
            AddCourse = new RelayCommand(AddCourseToList, CanAddToCourse);
            ItemSelected = new RelayCommand(ItemRemovedOrSelect, CanDelete);


            GetCourses();
            
        }
        #endregion

        //private async void AddCourseD() {
        //   var ll = await GetCourses();

        //    foreach (var item in ll) {
        //        CourseListItems.Add(item);
        //    }
        //}

        private bool CanSubmitStudent(object obj) {
            return true;
        }

        private void AddStudentComplete(object obj) {

            Student student = new Student {
                Name = this.Name,
                Email = this.Email,
                Faculty = this.Faculty,
                Sem = this.Semester,
                Matric = Convert.ToInt64(this.Matric),
                Phone = this.Phone,
            };

            List<Section> list = new List<Section>();

            foreach (var sc in SelectedOfferedCourseItem) {
                list.Add(new Section { 
                    Id=sc.SectionId,
                });
            }

            _registrationService.RegisterStudent(student,list).ContinueWith(task=> {
                if (task.Exception == null)
                {
                    Name = "";
                    Email = "";
                    Faculty = "";
                    Semester = "";
                    Matric = "";
                    Phone = "";

                    MessageBox.Show("Student Successfully Added", "Action Successfull", MessageBoxButton.OK, MessageBoxImage.Information);

                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(Faculty));
                    OnPropertyChanged(nameof(Semester));
                    OnPropertyChanged(nameof(Matric));
                    OnPropertyChanged(nameof(Phone));
                }
            });
        }

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
            if (SelectedOfferedCourseItem.Count>0 && SelectedOfferedCourseItem.Any(it=>it.CourseName == item2.CourseName)) {
                MessageBox.Show("Course Already in List", "Duplicate Found", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                SelectedOfferedCourseItem.Add(item2);
            }
            
        }

        private bool CanDelete(object obj)
        {
            return SelectdOfferedCourseListItemViewModel != null;
        }

        private void ItemRemovedOrSelect(object obj)
        {
            SelectedOfferedCourseItem.Remove(SelectdOfferedCourseListItemViewModel);
            SelectdOfferedCourseListItemViewModel = null;
        }

        private async void GetCourses() {
            var allSections = await _courseServices.GetAllSections();
            foreach (var section in allSections) {
                CourseListItems.Add(
               new AddStudentCourseListItemViewModel
               {
                   SectionId = section.Id,
                   CourseCode = section.Course.CourseCode,
                   Name = section.Course.CourseName,
                   LecturerName = section.Lecturer.User.Name,
                   IsSelected = false
               });
            }
        }
    }
}