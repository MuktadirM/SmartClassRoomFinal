using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.FaceProcessing;

namespace SmartClassRoom.Domain.Models.Core
{
    [Table("Students", Schema = "Admin")]
    public class Student : DomainObject
    {
        [Column(TypeName = "bigint")]
        public long Matric { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Sem { get; set; }
        
        [MaxLength(150)]
        public string Faculty { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [MaxLength(100)]
        public int CreatedBy { get; set; }

        public bool FaceAdded { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual StudentAddress Address { get; set; }
        
    }
}
