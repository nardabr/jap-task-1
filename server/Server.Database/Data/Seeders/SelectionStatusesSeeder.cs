using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Database.Data.Seeders
{
    public static class SelectionStatusesSeeder
    {
        public static void SeedSelectionStatuses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SelectionStatus>().HasData(
                new SelectionStatus { Id = 1, Name = "Active" },
                new SelectionStatus { Id = 2, Name = "Complete" }
                );
        }
    }
}
