using Microsoft.AspNetCore.Identity;

namespace Server.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}
