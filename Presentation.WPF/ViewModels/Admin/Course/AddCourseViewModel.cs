using Presentation.ViewModels;
using Presentation.WPF.Commands.Callbcks;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services.CourseServices;
using System;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class AddCourseViewModel
    /// Write your documentation here
    /// </summary>
    public class AddCourseViewModel : BaseViewModel

    {
        private readonly ICourseServices _services;

       

        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Semester { get; set; }
        public string Faculty { get; set; }

        public ICommand AddCourse { get; set; }

        #region constructor
        public AddCourseViewModel(ICourseServices services)
        {
            _services = services;
            AddCourse = new RelayACommand(AddToCourse);
        }
        #endregion

        public bool CanAddCourse()
        {
            return true;
        }

        public void AddToCourse()
        {

            Course course = new Course {
                CourseCode = this.CourseCode,
                CourseName = this.CourseName,
                Faculty = this.Faculty,
                Sem = Semester,
                CreatedAt = DateTime.Now,
                Deleted = false,
                CreatedBy = 2,
                LastUpdated = DateTime.Now,
                IsActive = true,
            };
            if (_services.Create(course) != null) {
                MessageBox.Show("Course Added ", "Successfull");
            }
            else
                MessageBox.Show("Course Fail to add ", "Successfull");


        }
    }
}