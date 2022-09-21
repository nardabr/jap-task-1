using jap_task.Dtos.User;
using jap_task.Models;

namespace jap_task.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Login(string email, string password);
    }
}
