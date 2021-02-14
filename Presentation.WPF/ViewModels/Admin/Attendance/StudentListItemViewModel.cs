
using System;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class LecturerListItemViewModel
    /// Write your documentation here
    /// </summary>
    public class StudentListItemViewModel
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Matric { get; set; }
        public bool FaceAdded { get; set; }
        public DateTime JoinDate { get; set; }
        public string Initials { get; set; }
        public bool IsSelected { get; set; }
        public string ProfilePictureRGB { get; set; }

        public string FaceFound => IsFaceFound();
        public ICommand UpdateSelectedItem { get; set; }
        public int Id { get; internal set; }
        #region constructor
        #endregion

        public string IsFaceFound() {
            if (FaceAdded) {
                return "Face Found";
            }
            return "No Face Found";
        }
    }
}