using Microsoft.EntityFrameworkCore;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.FaceProcessing;
using SmartClassRoom.Domain.Models.Users;

namespace DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentFaceData> StudentFaces { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<AttendProcess> AttendenceHistories { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options) { 
        }
    }
}
