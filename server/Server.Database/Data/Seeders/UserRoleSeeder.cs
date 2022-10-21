using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Database.Data.Seeders
{
    public static class UserRoleSeeder
    {
        public static void SeedUserRoles(this ModelBuilder builder)
        {
            builder.Entity<UserRole>(eb =>
            {
                // Transfer relationship from RoleId1 to RoleId, remove RoleId1
                var roleId = (Microsoft.EntityFrameworkCore.Metadata.Internal.Property)eb.Metadata.FindProperty("RoleId");
                var roleIdFk = eb.Metadata.FindForeignKeys(roleId).Single();
                eb.Metadata.RemoveForeignKey(roleIdFk);

                var roleId1 = eb.Metadata.FindProperty("RoleId1");
                var roleId1Fk = eb.Metadata.FindForeignKeys(roleId1).Single();

                var applicationRolePk = builder.Entity<Role>().Metadata.FindPrimaryKey();
                roleId1Fk.SetProperties(
                    new List<Microsoft.EntityFrameworkCore.Metadata.Internal.Property> { roleId }, applicationRolePk);

                eb.Metadata.RemoveProperty(roleId1);

                // Transfer relationship from UserId1 to UserId, remove UserId1
                var userId = (Microsoft.EntityFrameworkCore.Metadata.Internal.Property)eb.Metadata.FindProperty("UserId");
                var userIdFk = eb.Metadata.FindForeignKeys(userId).Single();
                eb.Metadata.RemoveForeignKey(userIdFk);

                var userId1 = eb.Metadata.FindProperty("UserId1");
                var userId1Fk = eb.Metadata.FindForeignKeys(userId1).Single();

                var applicationUserPk = builder.Entity<User>().Metadata.FindPrimaryKey();
                userId1Fk.SetProperties(
                    new List<Microsoft.EntityFrameworkCore.Metadata.Internal.Property> { userId }, applicationUserPk);

                eb.Metadata.RemoveProperty(userId1);
            });

            builder.Entity<UserRole>().HasData(
               new UserRole { UserId = -1, RoleId = 1 },
               new UserRole { UserId = 1, RoleId = 2 },
               new UserRole { UserId = 2, RoleId = 2 },
               new UserRole { UserId = 3, RoleId = 2 },
               new UserRole { UserId = 4, RoleId = 2 },
               new UserRole { UserId = 5, RoleId = 2 },
               new UserRole { UserId = 6, RoleId = 2 },
               new UserRole { UserId = 7, RoleId = 2 },
               new UserRole { UserId = 8, RoleId = 2 },
               new UserRole { UserId = 9, RoleId = 2 },
               new UserRole { UserId = 10, RoleId = 2 }
               );
        }
    }
}
