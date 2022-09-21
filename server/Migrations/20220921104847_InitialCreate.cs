using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "ProgramDescription", "ProgramName" },
                values: new object[,]
                {
                    { 1, "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. You can complete the program even sooner than 9 weeks if you work hard! Everything is up to you.", "JAP Dev" },
                    { 2, "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. If you work hard, you can complete the program even sooner than 5 weeks! Everything is up to you.", "JAP QA" },
                    { 3, "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. You can complete the program even sooner than 13 weeks if you work hard! Everything is up to you.", "JAP DevOps" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@mail.com", new byte[] { 100, 199, 243, 211, 106, 20, 244, 5, 110, 128, 203, 170, 72, 198, 80, 5, 246, 106, 85, 20, 122, 56, 117, 235, 168, 242, 58, 150, 19, 7, 22, 162, 164, 134, 84, 26, 200, 202, 138, 99, 175, 249, 170, 168, 193, 44, 212, 161, 210, 208, 44, 37, 82, 46, 80, 218, 9, 46, 5, 32, 223, 250, 49, 218 }, new byte[] { 94, 181, 84, 190, 99, 250, 117, 105, 131, 0, 98, 170, 221, 0, 62, 140, 52, 113, 249, 162, 150, 167, 185, 12, 74, 12, 130, 228, 7, 94, 136, 74, 102, 116, 47, 193, 123, 219, 137, 180, 218, 131, 51, 118, 116, 7, 87, 190, 65, 175, 142, 241, 121, 171, 187, 43, 37, 220, 70, 159, 178, 6, 225, 156, 62, 196, 122, 219, 192, 132, 233, 236, 247, 231, 35, 193, 234, 206, 117, 51, 38, 77, 25, 179, 166, 64, 57, 143, 121, 75, 8, 119, 51, 46, 28, 35, 237, 70, 33, 191, 236, 1, 115, 104, 216, 20, 24, 73, 136, 78, 3, 4, 65, 30, 21, 44, 3, 17, 224, 133, 7, 96, 212, 115, 225, 196, 60, 230 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
