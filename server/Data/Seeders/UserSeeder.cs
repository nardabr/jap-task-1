using jap_task.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server.Data.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = -1,
                    UserName = "admin",
                    Email = "admin@email.com",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 1,
                    UserName = "adalovelace",
                    Email = "adalovelace@email.com",
                    NormalizedEmail = "ADALOVELACE@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 2,
                    UserName = "gracehopper",
                    Email = "gracehopper@email.com",
                    NormalizedEmail = "GRACEHOPPER@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 3,
                    UserName = "joanclarke",
                    Email = "joanclarke@email.com",
                    NormalizedEmail = "JOANCLARKE@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 4,
                    UserName = "harrypotter",
                    Email = "harrypotter@email.com",
                    NormalizedEmail = "HARRYPOTTER@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 5,
                    UserName = "hermionegranger",
                    Email = "hermionegranger@email.com",
                    NormalizedEmail = "HERMIONEGRANGER@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 6,
                    UserName = "ronweasley",
                    Email = "ronweasley@email.com",
                    NormalizedEmail = "RONWEASLEY@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 7,
                    UserName = "albusdumbledore",
                    Email = "albusdumbledore@email.com",
                    NormalizedEmail = "ALBUSDUMBLEDORE@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 8,
                    UserName = "lordvoldemort",
                    Email = "lordvoldemort@email.com",
                    NormalizedEmail = "LORDVOLDEMORT@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 9,
                    UserName = "dracomalfoy",
                    Email = "dracomalfoy@email.com",
                    NormalizedEmail = "DRACOMALFOY@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                },
                new User
                {
                    Id = 10,
                    UserName = "siriusblack",
                    Email = "siriusblack@email.com",
                    NormalizedEmail = "SIRIUSBLACK@EMAIL.COM",
                    PasswordHash = passwordHasher.HashPassword(null, "Password123$"),
                }
            );
        }

    }
}
