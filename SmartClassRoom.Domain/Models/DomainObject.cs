using System.ComponentModel.DataAnnotations;

namespace SmartClassRoom.Domain.Models
{
    public enum UserType {
        Root,
        Admin,
        Lecturer,
        Student
    }

    public class DomainObject
    {
        [Key]public int Id { get; set; }
    }
}
