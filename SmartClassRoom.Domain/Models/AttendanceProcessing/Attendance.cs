using SmartClassRoom.Domain.Models.Core;
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
        //  public int CourseId{ get; set; }
        //  public int LecturerId{ get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? Deleted { get; set; }

        public Student Student{ get; set; }
        public AttendProcess AttendProcess{ get; set; }
        //  public virtual Course Course{ get; set; }
        //  public virtual Lecturer Lecturer { get; set; }
    }
}
