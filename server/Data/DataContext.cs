using jap_task.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using server.Data.Seeders;
using System.Security.Cryptography;

namespace jap_task.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                CreateAdmin(1, "admin@mail.com", "admin1234")
            );

            modelBuilder.SeedPrograms();

            modelBuilder.SeedSelectionStatuses();

            modelBuilder.SeedSelections();

            modelBuilder.SeedStudentStatuses();

            modelBuilder.SeedStudents();
        }

        public static User CreateAdmin(int id, string email, string password)
        {
            var admin = new User();

            DataContext.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;
            admin.Id = id;
            admin.Email = email;
            return admin;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Program> Programs { get; set; }
        public DbSet<SelectionStatus> SelectionStatuses { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<StudentStatus> StudentStatuses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
