using Server.Core.Entities;
using Server.Core.Requests.User;

namespace Server.Database.Data
{
    public interface IAuthRepository
    {
        Task<User> InsertUser(UserInsertRequest insert);
        public Task<dynamic> Login(UserLoginDto req);

    }
}
