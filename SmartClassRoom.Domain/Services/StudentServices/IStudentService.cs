using SmartClassRoom.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services
{
    public interface IStudentService : IDataService<Student>
    {
        Task<Student> GetByMatric(Int64 matric);
    }
}
