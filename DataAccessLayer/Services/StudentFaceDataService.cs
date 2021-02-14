
using DataAccessLayer.Services.Common;
using SmartClassRoom.Domain.Models.FaceProcessing;
using SmartClassRoom.Domain.Services.FaceServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class StudentFaceDataService
    /// Write your documentation here
    /// </summary>
    public class StudentFaceDataService : IStudentFaceDataServices
    {
        private readonly DatabaseContextFactory _contextFactory;
        private readonly NonQueryDataService<StudentFaceData> _nonQueryDataService;

        public StudentFaceDataService(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<StudentFaceData>(contextFactory);
        }


        #region constructor
        #endregion
        public Task<StudentFaceData> Create(StudentFaceData entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<StudentFaceData>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<StudentFaceData> GetOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<StudentFaceData> Update(int id, StudentFaceData entity)
        {
            throw new System.NotImplementedException();
        }
    }
}