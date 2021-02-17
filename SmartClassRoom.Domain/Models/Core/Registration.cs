using SmartClassRoom.Domain.Models.AttendanceProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassRoom.Domain.Models.Core
{
    [Table("Registrations", Schema = "Admin")]
    public class Registration : DomainObject
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }

        [MaxLength(40)]
        public string Intake { get; set; } = "43431";

        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? Deleted { get; set; }
        
        public virtual Section Section { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

    }
}