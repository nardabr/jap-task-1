using Microsoft.AspNetCore.Identity;
using server.Models;

namespace jap_task.Models
{
    public class User : IdentityUser<int>
    {
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}
