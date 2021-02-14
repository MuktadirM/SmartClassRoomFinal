using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetOne(int id);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
