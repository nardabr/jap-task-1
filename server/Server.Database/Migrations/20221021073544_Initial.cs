using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selections_SelectionStatuses_SelectionStatusId",
                        column: x => x.SelectionStatusId,
                        principalTable: "SelectionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentStatusId = table.Column<int>(type: "int", nullable: false),
                    SelectionId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_StudentStatuses_StudentStatusId",
                        column: x => x.StudentStatusId,
                        principalTable: "StudentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "325435", "admin", "ADMIN" },
                    { 2, "2362452", "student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { -1, 0, "957078a2-d960-4d39-86ab-ec34a265a33a", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", null, "AQAAAAEAACcQAAAAECeiWq4esZM0udz7haENwBV1/E0UqxtXQq3dCFAUiMoDiS3WNFq98HGglHxRc2pvew==", null, false, null, 1, false, "admin" },
                    { 1, 0, "fc498eca-51bb-4c43-a4ad-9012eb3189a1", "adalovelace@email.com", false, false, null, "ADALOVELACE@EMAIL.COM", null, "AQAAAAEAACcQAAAAEL1OD7qMWwqXsDdMKFKEOa9RN34+EVYGdVQEdG4q9QLTp7reiYcoz1nm1escjIRUJw==", null, false, null, 1, false, "adalovelace" },
                    { 2, 0, "1a294858-b0df-49de-a82f-633911660649", "gracehopper@email.com", false, false, null, "GRACEHOPPER@EMAIL.COM", null, "AQAAAAEAACcQAAAAEPOwD3uKUIaLCFOmJEYTIh414Cqht5ewSpJKeME91Th4Rqb64cxSUb510EFo8yaqSw==", null, false, null, 1, false, "gracehopper" },
                    { 3, 0, "21f312b8-c595-495f-ba47-61b4b42b388e", "joanclarke@email.com", false, false, null, "JOANCLARKE@EMAIL.COM", null, "AQAAAAEAACcQAAAAEItIFOezclUXvOrJ7+lcV2ocS77JgkA2HBMOqiebcGiJUstUYdIUUqVOSka7AXMjKw==", null, false, null, 1, false, "joanclarke" },
                    { 4, 0, "09076358-6047-4afa-b1fe-653f6a272674", "harrypotter@email.com", false, false, null, "HARRYPOTTER@EMAIL.COM", null, "AQAAAAEAACcQAAAAECqHrBHs0Wrx5QY6NQrdeRcxNUCO2C6IQ2Rql8mib7V3fq0DtoQEGQ0Bx/BSPLEbXg==", null, false, null, 1, false, "harrypotter" },
                    { 5, 0, "39826596-9ecb-41bc-9eb8-f0dfedbff35b", "hermionegranger@email.com", false, false, null, "HERMIONEGRANGER@EMAIL.COM", null, "AQAAAAEAACcQAAAAEKMTbVLrPmva9EowKocAkPHwHpcURL+Ib9xVMccArmpBIs486dwqzMTO1aquGOmxhg==", null, false, null, 1, false, "hermionegranger" },
                    { 6, 0, "430c2190-b4bb-4d0b-a6ce-ca7400c332ba", "ronweasley@email.com", false, false, null, "RONWEASLEY@EMAIL.COM", null, "AQAAAAEAACcQAAAAENPbZHlzntxhVynxPiUE0L2ZAitiJyhGYWjpkwxo9+4OAlCEiUnkf3FlADMowqWqVg==", null, false, null, 1, false, "ronweasley" },
                    { 7, 0, "98ed6bfc-5883-448f-bcd1-c4657d110dc5", "albusdumbledore@email.com", false, false, null, "ALBUSDUMBLEDORE@EMAIL.COM", null, "AQAAAAEAACcQAAAAELtgLyFVyTOEoMLK5gtRpuvmQkAD+66uP619uW38rbKKmCn+26mP7vjKUq780z6CEA==", null, false, null, 1, false, "albusdumbledore" },
                    { 8, 0, "e3485fc0-ca9a-445b-9842-44b01687933b", "lordvoldemort@email.com", false, false, null, "LORDVOLDEMORT@EMAIL.COM", null, "AQAAAAEAACcQAAAAELZDw+tQepv1jsm2C+dThdKkqQ5BfxzNCSGxQcQC2ofruYCkm9vqoGwmZ54Hm5ZYeA==", null, false, null, 1, false, "lordvoldemort" },
                    { 9, 0, "0a9d721f-6569-4d39-9986-edba64da28e0", "dracomalfoy@email.com", false, false, null, "DRACOMALFOY@EMAIL.COM", null, "AQAAAAEAACcQAAAAEApErfyR53/CvURHO/CKD14mF+LUIolxMB9j+8j2If9nuYzloEohDYud2wUsjBFHuA==", null, false, null, 1, false, "dracomalfoy" },
                    { 10, 0, "32fd14a9-49ad-4589-aef6-68582bef7274", "siriusblack@email.com", false, false, null, "SIRIUSBLACK@EMAIL.COM", null, "AQAAAAEAACcQAAAAEGDZpaYEX9T/4JguLI+LYz9FRb1O8YByuQTVtdcVhLtEv8wClnOWd9jEQFgDe635Cw==", null, false, null, 1, false, "siriusblack" }
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, -1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "EndAt", "Name", "ProgramId", "SelectionStatusId", "StartAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAP Dev 09/2022", 1, 1, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAP QA 08/2022", 2, 1, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAP DevOps 09/2022", 3, 1, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "SelectionId", "StudentStatusId", "UserId" },
                values: new object[,]
                {
                    { 1, "Ada", "Lovelace", 1, 1, 1 },
                    { 2, "Grace", "Hopper", 2, 2, 2 },
                    { 3, "Joan", "Clarke", 3, 4, 3 },
                    { 4, "Harry", "Potter", 1, 2, 4 },
                    { 5, "Hermione", "Granger", 2, 2, 5 },
                    { 6, "Ron", "Weasley", 3, 3, 6 },
                    { 7, "Albus", "Dumbledore", 1, 1, 7 },
                    { 8, "Lord", "Voldemort", 2, 3, 8 },
                    { 9, "Draco", "Malfoy", 3, 3, 9 },
                    { 10, "Sirius", "Black", 1, 4, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GetOverallSuccesRate");

            migrationBuilder.DropTable(
                name: "GetSelectionsSuccessRates");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
