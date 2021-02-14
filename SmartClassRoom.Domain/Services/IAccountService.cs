using SmartClassRoom.Domain.Models.Core;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services
{
    public enum UpdateResult
    {
        Success,
        PassSame,
        PassNotMatch,
        NetworkFail,
        PassEmpty,
    }

    public interface IAccountService : IDataService<User>
    {
        Task<User> GetByEmail(string email);
        Task<Account> GetAccountById(int Id);
        Task<UpdateResult> UpdatePassword(User user,string current,string updated);
    }
}
