using jap_task.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Data.Seeders;
using System.Reflection;
using jap_task.Dtos.Selection;

namespace jap_task.Data
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
        }

        public DbSet<Models.Program> Programs { get; set; }
        public DbSet<SelectionStatus> SelectionStatuses { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<StudentStatus> StudentStatuses { get; set; }   
        public DbSet<Student> Students { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GetSelectionsSuccesRatesDto> GetSelectionsSuccessRates { get; set; }
        public DbSet<GetOverallSuccesRateDto> GetOverallSuccesRate { get; set; }


    }
}
