using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Database.Data.Seeders
{
    public static class SelectionsSeeder
    {
        public static void SeedSelections(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Selection>().HasData(
                new Selection { Id = 1, Name = "JAP Dev 09/2022", StartAt = new DateTime(2022, 09, 05), EndAt = new DateTime(2022, 11, 20), SelectionStatusId = 1, ProgramId = 1 },
                new Selection { Id = 2, Name = "JAP QA 08/2022", StartAt = new DateTime(2022, 08, 08), EndAt = new DateTime(2022, 09, 12), SelectionStatusId = 1, ProgramId = 2 },
                new Selection { Id = 3, Name = "JAP DevOps 09/2022", StartAt = new DateTime(2022, 09, 05), EndAt = new DateTime(2022, 12, 04), SelectionStatusId = 1, ProgramId = 3 }
                );
        }
    }
}
