using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Database.Data.Seeders
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
