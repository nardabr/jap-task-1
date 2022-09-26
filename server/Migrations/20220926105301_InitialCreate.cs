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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectionStatusId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selections_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Selections_SelectionStatuses_SelectionStatusId",
                        column: x => x.SelectionStatusId,
                        principalTable: "SelectionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentStatusId = table.Column<int>(type: "int", nullable: false),
                    SelectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_StudentStatuses_StudentStatusId",
                        column: x => x.StudentStatusId,
                        principalTable: "StudentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. You can complete the program even sooner than 9 weeks if you work hard! Everything is up to you.", "JAP Dev" },
                    { 2, "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. If you work hard, you can complete the program even sooner than 5 weeks! Everything is up to you.", "JAP QA" },
                    { 3, "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities. You can complete the program even sooner than 13 weeks if you work hard! Everything is up to you.", "JAP DevOps" }
                });

            migrationBuilder.InsertData(
                table: "SelectionStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Complete" }
                });

            migrationBuilder.InsertData(
                table: "StudentStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "In Program" },
                    { 2, "Success" },
                    { 3, "Failed" },
                    { 4, "Extended" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@mail.com", new byte[] { 198, 227, 92, 255, 154, 50, 54, 235, 174, 73, 241, 121, 249, 144, 234, 104, 104, 181, 221, 237, 158, 129, 241, 190, 78, 161, 46, 103, 184, 55, 56, 149, 222, 24, 246, 181, 47, 5, 16, 17, 3, 166, 47, 120, 63, 167, 48, 50, 233, 216, 148, 12, 44, 235, 246, 98, 165, 35, 193, 207, 144, 136, 222, 221 }, new byte[] { 21, 31, 56, 65, 83, 36, 148, 92, 165, 161, 163, 14, 177, 54, 92, 253, 246, 78, 70, 194, 0, 85, 49, 180, 92, 157, 253, 114, 63, 149, 35, 58, 249, 155, 41, 95, 83, 114, 155, 208, 148, 190, 232, 21, 223, 102, 77, 23, 94, 160, 193, 184, 104, 99, 136, 169, 45, 15, 170, 171, 198, 19, 236, 253, 22, 46, 40, 75, 255, 192, 68, 242, 204, 125, 40, 6, 8, 92, 121, 53, 140, 56, 93, 209, 217, 108, 209, 166, 58, 128, 54, 99, 168, 135, 43, 235, 246, 96, 208, 109, 106, 109, 226, 251, 248, 238, 79, 46, 147, 139, 75, 253, 47, 198, 244, 19, 26, 220, 206, 199, 38, 49, 253, 58, 71, 143, 48, 126 } });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "EndAt", "Name", "ProgramId", "SelectionStatusId", "StartAt" },
                values: new object[] { 1, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAP Dev 09/2022", 1, 1, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "EndAt", "Name", "ProgramId", "SelectionStatusId", "StartAt" },
                values: new object[] { 2, new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAP QA 08/2022", 2, 1, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "EndAt", "Name", "ProgramId", "SelectionStatusId", "StartAt" },
                values: new object[] { 3, new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAP DevOps 09/2022", 3, 1, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "SelectionId", "StudentStatusId" },
                values: new object[,]
                {
                    { 1, "Ada", "Lovelace", 1, 1 },
                    { 2, "Grace", "Hopper", 2, 2 },
                    { 3, "Joan", "Clarke", 3, 4 },
                    { 4, "Harry", "Potter", 1, 1 },
                    { 5, "Hermione", "Granger", 2, 2 },
                    { 6, "Ron", "Weasley", 3, 3 },
                    { 7, "Albus", "Dumbledore", 1, 1 },
                    { 8, "Lord", "Voldemort", 2, 3 },
                    { 9, "Draco", "Malfoy", 3, 3 },
                    { 10, "Sirius", "Black", 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selections_ProgramId",
                table: "Selections",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_SelectionStatusId",
                table: "Selections",
                column: "SelectionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SelectionId",
                table: "Students",
                column: "SelectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentStatusId",
                table: "Students",
                column: "StudentStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "StudentStatuses");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "SelectionStatuses");
        }
    }
}
