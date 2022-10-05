using jap_task.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data.Seeders
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
