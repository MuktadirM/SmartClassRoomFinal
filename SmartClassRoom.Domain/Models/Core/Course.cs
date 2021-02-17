using SmartClassRoom.Domain.Models.AttendanceProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassRoom.Domain.Models.Core
{
    [Table("Courses", Schema = "Admin")]
    public class Course : DomainObject
    {
        [MaxLength(150)]
        public string CourseName { get; set; }
        [MaxLength(150)]
        public string CourseCode { get; set; }
        [MaxLength(10)]
        public string Sem { get; set; }
        [MaxLength(150)]
        public string Faculty { get; set; }
        
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
        
    }
}
