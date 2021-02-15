
using Presentation.ViewModels;
using Presentation.WPF.Commands.Callbcks;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.CourseServices;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Users;
using System.Collections.Generic;
using static SmartClassRoom.Domain.Services.ILecturerService;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class AddLectuerViewModel
    /// Write your documentation here
    /// </summary>
    public class AddLectuerViewModel : BaseViewModel
    {
        private readonly ICourseServices _courseServices;
        private readonly ILecturerService _lecturserService;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Faculty { get; set; }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister => !string.IsNullOrEmpty(Email) &&
           !string.IsNullOrEmpty(Password);
           //!string.IsNullOrEmpty(ConfirmPassword);

        public ObservableCollection<AddLecturerCourseListItemViewModel> CourseListItems { get; set; } = 
            new ObservableCollection<AddLecturerCourseListItemViewModel>();

        public ObservableCollection<LecturerSelectedCourseListItemViewModel> SelectedOfferedCourseItem { get; set; } = 
            new ObservableCollection<LecturerSelectedCourseListItemViewModel>();

        public LecturerSelectedCourseListItemViewModel SelectdOfferedCourseListItemViewModel { get; set; }

        public AddLecturerCourseListItemViewModel SelectedCourseItem { get; set; }

        public ICommand AddLectuer { get; set; }
        public ICommand AddCourse { get; set; }

        public ICommand ItemSelected { get; set; }

        #region constructor
        public AddLectuerViewModel(ICourseServices courseServices, ILecturerService lecturserService)
        {
            _courseServices = courseServices;
            _lecturserService = lecturserService;

            AddLectuer = new RelayCommand(AddLecturerComplete, CanSubmitStudent);
            AddCourse = new RelayCommand(AddCourseToList, CanAddToCourse);
            ItemSelected = new RelayCommand(ItemRemovedOrSelect, CanDelete);

            UpdateCourse();
        }
        #endregion

        private bool CanSubmitStudent(object obj)
        {
            return true;
        }

        private async void UpdateCourse() {
            var course = await GetCourseItems();

            foreach (var item in course) {
                CourseListItems.Add(item);
            }
        }


        private void AddLecturerComplete(object obj)
        {

            User user = new User {
                Name = this.Name,
                Password = this.Password,
                Email = this.Email,
                Phone = this.Phone,
                Image = "https://via.placeholder.com/150",
            };

            Lecturer lecturer = new Lecturer {
                Faculty = this.Faculty,
                User = user,
            };

            List<Course> list = new List<Course>();

            foreach (var c in SelectedOfferedCourseItem) {
                list.Add(
                    new Course { 
                        Id = c.Id,
                        CourseName = c.Name,
                        CourseCode = c.CourseCode
                        }
                    );
            
            }

            _lecturserService.CreateLecturer(lecturer, list).ContinueWith(task=> {
                if (task.Result == LecturerRegistrationResult.Success)
                {
                    Name = "";
                    Password = "";
                    Email = "";
                    Phone = "";
                    Faculty = "";

                    MessageBox.Show("Lecturer Added", "Action Successfull", MessageBoxButton.OK, MessageBoxImage.Information);

                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(Password));
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(Phone));
                    OnPropertyChanged(nameof(Faculty));

                }
                else if (task.Result == LecturerRegistrationResult.EmailAlreadyExists)
                {
                    MessageBox.Show("Lecturer Email Already Exsist", "Action Successfull", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (task.Result == LecturerRegistrationResult.ZeroCourseFound)
                {
                    MessageBox.Show("Lecturer Does not have any course", "Action Successfull", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else {
                    MessageBox.Show("Unknown Error", "Action Successfull", MessageBoxButton.OK, MessageBoxImage.Error);
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
            var item2 = new LecturerSelectedCourseListItemViewModel
            {
                Id = item.Id,
                CourseCode = item.CourseCode,
                Name = item.Name,
                CourseId = item.CourseId,
            };

            SelectedOfferedCourseItem.Add(item2);
        }

        private bool CanDelete(object obj)
        {
            return SelectdOfferedCourseListItemViewModel != null;
        }

        private void ItemRemovedOrSelect(object obj)
        {
            //SelectdOfferedCourseListItemViewModel = (StudentOfferedCourseListItemViewModel)obj;
            //MessageBox.Show(_selectdOfferedCourseListItemViewModel.CourseName + "Item Remove", "Check");
            // MessageBox.Show("Can not Remove "+ SelectdOfferedCourseListItemViewModel.ToString(), "Check");
            SelectedOfferedCourseItem.Remove(SelectdOfferedCourseListItemViewModel);
            SelectdOfferedCourseListItemViewModel = null;
        }

        private async Task<ObservableCollection<AddLecturerCourseListItemViewModel>> GetCourseItems()
        {
            ObservableCollection<AddLecturerCourseListItemViewModel> items = new ObservableCollection<AddLecturerCourseListItemViewModel>();
            var courseList = await _courseServices.GetAll();

            foreach(var course in courseList)
            {
                items.Add(new AddLecturerCourseListItemViewModel {
                        Id = course.Id,
                        Name = course.CourseName,
                        CourseCode = course.CourseCode,
                        Faculty = course.Faculty,
                    });
            }

            return items;
        }

    }
}