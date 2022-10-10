using jap_task.Dtos.User;
using jap_task.Models;
using NuGet.Protocol.Plugins;

namespace jap_task.Data
{
    public interface IAuthRepository
    {
        Task<User> InsertUser(UserInsertRequest insert);
        public Task<dynamic> Login(UserLoginDto req);

    }
}
