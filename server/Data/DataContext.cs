using jap_task.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
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

            modelBuilder.Entity<Models.Program>().HasData(
                new Models.Program { Id = 1, ProgramName = "JAP Dev", ProgramDescription = "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. You can complete the program even sooner than 9 weeks if you work hard! Everything is up to you." },
                new Models.Program { Id = 2, ProgramName = "JAP QA", ProgramDescription = "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. If you work hard, you can complete the program even sooner than 5 weeks! Everything is up to you." },
                new Models.Program { Id = 3, ProgramName = "JAP DevOps", ProgramDescription = "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. You can complete the program even sooner than 13 weeks if you work hard! Everything is up to you." }

                );

            //modelBuilder.Entity<SelectionStatus>().HasData(
            //    new SelectionStatus { Id = 1, Name = "Active" },
            //    new SelectionStatus { Id = 1, Name = "Complete" }

            //    );
            //modelBuilder.Entity<Selection>().HasData(
            //    new Selection { Id = 1, Name = "JAP Dev 09/2022", StartAt = new DateTime(2022, 09, 05), EndAt = new DateTime(2022, 11, 20) },
            //    new Selection { Id = 2, Name = "JAP QA 08/2022", StartAt = new DateTime(2022, 08, 08), EndAt = new DateTime(2022, 09, 12) },
            //    new Selection { Id = 2, Name = "JAP DevOps 09/2022", StartAt = new DateTime(2022, 09, 05), EndAt = new DateTime(2022, 12, 04) }
            //    );
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

    }
}
