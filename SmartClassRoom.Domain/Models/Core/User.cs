using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassRoom.Domain.Models.Core
{
    [Table("Users", Schema = "Admin")]
    public class User : DomainObject
    {
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        public string Image { get; set; }
        [MaxLength(10)]
        public int Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool? Deleted { get; set; }
    }
}
