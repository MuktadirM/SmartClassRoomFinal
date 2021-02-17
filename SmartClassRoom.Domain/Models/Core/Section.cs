using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.Users;

namespace SmartClassRoom.Domain.Models.Core
{
    [Table("Sections", Schema = "Admin")]
    public class Section : DomainObject
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        
        [ForeignKey("Lecturer")]
        public int LecturerId { get; set; }
        
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? Deleted { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual Course Course { get; set; }   
        public virtual AttendProcess AttendProcess { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
    }
}