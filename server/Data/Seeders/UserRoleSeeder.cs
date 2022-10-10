using jap_task.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data.Seeders
{
    public static class UserRoleSeeder
    {
        public static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
               new UserRole { UserId = -1, RoleId = 1 },
               new UserRole { UserId = 1, RoleId = 2 }
               );
        }
    }
}
