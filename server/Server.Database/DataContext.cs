using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Server.Core.Entities;
using Server.Core.Requests.Selection;
using Server.Database.Data.Seeders;
using Microsoft.Extensions.Options;


namespace Server.Database
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SeedRoles();
            modelBuilder.SeedUsers();
            modelBuilder.SeedUserRoles();
            modelBuilder.SeedPrograms();
            modelBuilder.SeedSelectionStatuses();
            modelBuilder.SeedSelections();
            modelBuilder.SeedStudentStatuses();
            modelBuilder.SeedStudents();
            modelBuilder.SeedLectureEvents();
            modelBuilder.SeedStudentLectureEvents();
        }

        public DbSet<Core.Entities.Program> Programs { get; set; }
        public DbSet<SelectionStatus> SelectionStatuses { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<StudentStatus> StudentStatuses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GetSelectionsSuccesRatesDto> GetSelectionsSuccessRates { get; set; }
        public DbSet<GetOverallSuccesRateDto> GetOverallSuccesRate { get; set; }
        public DbSet<LectureEvent> LectureEvents { get; set; }
        public DbSet<StudentLectureEvents> StudentLectureEvents { get; set; }
    }
}
