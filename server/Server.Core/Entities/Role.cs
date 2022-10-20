using Microsoft.AspNetCore.Identity;

namespace Server.Core.Entities
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
