using SmartClassRoom.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services
{
    public interface IRegistrationService : IDataService<Registration>
    {
        public Task RegisterStudent(Student student, List<Section> sections);
        public Task RemoveStudent(Student student);
        public Task<IEnumerable<Registration>> RegistrationsByLecturer(int id);
    }
}
