
using SmartClassRoom.Domain.Models.Users;

namespace SmartClassRoom.Domain.Models.Core
{
    /// <summary>
    /// Class Account
    /// Write your documentation here
    /// </summary>
    public class Account
    {
        public User User { get; set; }

        #nullable enable
        public Lecturer? Lecturer { get; set; }
        public Student? Students { get; set; }
    }
}