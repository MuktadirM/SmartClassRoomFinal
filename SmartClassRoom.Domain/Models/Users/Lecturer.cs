using SmartClassRoom.Domain.Models.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassRoom.Domain.Models.Users
{
    [Table("Lecturers", Schema = "Admin")]
    public class Lecturer : DomainObject
    {
        [ForeignKey("User")]
        public int UserId { get; set;}

        [MaxLength(150)]
        public string Faculty { get; set; }

        public User User { get; set; }
        public List<Section> Sections { get; set; }
    }
}
