using Microsoft.AspNetCore.Identity;

namespace jap_task.Models
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
