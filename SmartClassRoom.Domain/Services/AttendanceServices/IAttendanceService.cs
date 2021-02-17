using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services
{
    public interface IAttendanceService : IDataService<Attendance>
    {
        public Task<Attendance> TakeAttendance(Student student, Attendance type);
        public Task<IEnumerable<Attendance>> GetBySection(List<int> section);
        public Task<Attendance> UpdateAttendanceOnly(Attendance latest);
    }
}
