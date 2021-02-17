using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SmartClassRoom.Domain.Models.Core;

namespace SmartClassRoom.Domain.Models.AttendanceProcessing
{
    [Table("AttendenceHistories", Schema = "Admin")]
    public class AttendProcess
    {
        [ForeignKey("Section")]
        public int AttendProcessId { get; set; }
        
        public int CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}