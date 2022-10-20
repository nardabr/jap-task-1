using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Database.Data.Seeders
{
    public static class RoleSeeder
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                           new Role { Id = 1, Name = "admin", NormalizedName = "ADMIN", ConcurrencyStamp = "325435" },
                           new Role { Id = 2, Name = "student", NormalizedName = "STUDENT", ConcurrencyStamp = "2362452" }
                       );
        }
    }
}
