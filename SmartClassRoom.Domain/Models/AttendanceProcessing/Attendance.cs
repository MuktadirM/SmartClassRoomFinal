using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassRoom.Domain.Models.AttendanceProcessing
{
    public enum AttendanceType{ 
        Absent,
        Present,
        Excuse,
        Undetected
    }

    [Table("Attendances", Schema = "Lecturer")]
    public class Attendance : DomainObject
    {
        public int AttendanceType { get; set; }

        public DateTime Time { get; set; }
        
      //  [ForeignKey("Student")]
        public int StudentId{ get; set; }

        [ForeignKey("AttendProcess")]
        public int AttendProcessId{ get; set; }

        public int CourseId{ get; set; }
        public int LecturerId { get; set; }

        [ForeignKey("Registration")]
        public int? RegistrationId { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? Deleted { get; set; }

        public AttendProcess AttendProcess{ get; set; }
        public Registration Registration { get; set; }
    }
}
