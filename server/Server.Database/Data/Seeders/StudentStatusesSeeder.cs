using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Database.Data.Seeders
{
    public static class StudentStatusesSeeder
    {
        public static void SeedStudentStatuses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentStatus>().HasData(
                new StudentStatus { Id = 1, Name = "In Program" },
                new StudentStatus { Id = 2, Name = "Success" },
                new StudentStatus { Id = 3, Name = "Failed" },
                new StudentStatus { Id = 4, Name = "Extended" }
                );
        }
    }
}
