using Microsoft.AspNetCore.Identity;

namespace Server.Core.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
