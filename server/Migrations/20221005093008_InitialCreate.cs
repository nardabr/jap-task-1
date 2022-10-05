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
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { 1, "admin@mail.com", new byte[] { 46, 127, 182, 40, 42, 159, 148, 32, 97, 72, 35, 203, 38, 105, 43, 75, 217, 50, 151, 15, 222, 23, 148, 136, 15, 185, 83, 184, 170, 129, 82, 134, 65, 175, 161, 68, 54, 4, 134, 165, 223, 32, 147, 196, 119, 171, 114, 173, 209, 91, 169, 136, 239, 88, 233, 163, 87, 119, 20, 143, 221, 236, 188, 227 }, new byte[] { 80, 42, 255, 184, 209, 195, 210, 20, 15, 26, 68, 240, 193, 108, 91, 180, 106, 43, 11, 10, 18, 226, 187, 191, 255, 190, 128, 92, 73, 215, 108, 44, 144, 61, 108, 173, 212, 65, 2, 181, 167, 42, 5, 129, 2, 5, 239, 235, 49, 103, 170, 35, 4, 64, 231, 251, 136, 159, 153, 115, 56, 63, 104, 188, 95, 38, 92, 25, 52, 243, 149, 26, 133, 181, 93, 249, 136, 23, 214, 130, 166, 181, 163, 225, 215, 76, 163, 71, 2, 224, 17, 116, 139, 48, 165, 86, 151, 17, 177, 29, 116, 124, 33, 87, 112, 177, 166, 236, 2, 253, 113, 135, 202, 209, 3, 56, 127, 12, 199, 140, 239, 71, 196, 128, 182, 126, 190, 10 }, 1 });

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
