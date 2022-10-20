using Microsoft.EntityFrameworkCore;

namespace Server.Database.Data.Seeders
{
    public static class ProgramsSeeder
    {
        public static void SeedPrograms(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.Program>().HasData(
                new Core.Entities.Program { Id = 1, Name = "JAP Dev", Description = "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. You can complete the program even sooner than 9 weeks if you work hard! Everything is up to you." },
                new Core.Entities.Program { Id = 2, Name = "JAP QA", Description = "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. If you work hard, you can complete the program even sooner than 5 weeks! Everything is up to you." },
                new Core.Entities.Program { Id = 3, Name = "JAP DevOps", Description = "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. You can complete the program even sooner than 13 weeks if you work hard! Everything is up to you." }
                );
        }
    }
}
