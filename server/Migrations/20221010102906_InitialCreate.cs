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
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    RoleId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { -1, 0, "452db54b-5e18-48b3-a05a-46f4addbfd68", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", null, "AQAAAAEAACcQAAAAENjX/hGawTV15urFrTa4lKE5r1uFnosbN060e6WzLLUlD17Czq7/0juoahknRzvTXw==", null, false, null, 1, false, "admin" },
                    { 1, 0, "63c37c31-d005-428b-9501-c583b32e6af7", "adalovelace@email.com", false, false, null, "ADALOVELACE@EMAIL.COM", null, "AQAAAAEAACcQAAAAEFweT0ZuACh1cj+SsUf7dTxxoiMxehGA9slfUs33aX/0xylXjpCF0uHhqLD/phrBAA==", null, false, null, 1, false, "adalovelace" },
                    { 2, 0, "4dd66327-e806-4ec3-b87a-35407c3c8228", "gracehopper@email.com", false, false, null, "GRACEHOPPER@EMAIL.COM", null, "AQAAAAEAACcQAAAAEBF8pE7YbtIigueCgycoeqTz8kzjXw9zcO5RuZME234Xmc21vHOgyWRceCM6Ed+WLw==", null, false, null, 1, false, "gracehopper" },
                    { 3, 0, "98ebd573-bbd7-4fca-99e6-933db9a25992", "joanclarke@email.com", false, false, null, "JOANCLARKE@EMAIL.COM", null, "AQAAAAEAACcQAAAAENsxbKF4swo3QxLOb1N3LLNy+Pl7QY4tU3E2e7UUSxeC7S3X18Ejsr5IybctH+ElFw==", null, false, null, 1, false, "joanclarke" },
                    { 4, 0, "0f8a789a-caf4-4ca5-825e-83d4a5a0fadc", "harrypotter@email.com", false, false, null, "HARRYPOTTER@EMAIL.COM", null, "AQAAAAEAACcQAAAAEBL81K+3PuvYYW3pOVrApCmRZF/Q5WJpybFeraP4C3AOW3vqYErLcedEu4QQuOH6OA==", null, false, null, 1, false, "harrypotter" },
                    { 5, 0, "55b98a02-d70e-4870-ae97-9f9d1bf26936", "hermionegranger@email.com", false, false, null, "HERMIONEGRANGER@EMAIL.COM", null, "AQAAAAEAACcQAAAAEBbV85zXw3917/HkCog/4ThEZDcdoYDDbgCojBGXgP0ZRTVsztBXu2tEbvdm1lhwMw==", null, false, null, 1, false, "hermionegranger" },
                    { 6, 0, "791c9d7e-d056-4ba0-a68f-0df5c2fef87c", "ronweasley@email.com", false, false, null, "RONWEASLEY@EMAIL.COM", null, "AQAAAAEAACcQAAAAEG93+icmCZG6ScvxfeLuQ/s5o77srrw4t5DnxImPRd3mjKBqLmsYm8KMr5ChzB9kmg==", null, false, null, 1, false, "ronweasley" },
                    { 7, 0, "c17be1f9-86f7-477a-a5d4-e72bb389364f", "albusdumbledore@email.com", false, false, null, "ALBUSDUMBLEDORE@EMAIL.COM", null, "AQAAAAEAACcQAAAAEIviyITWJgN3ZURq/TiERAyJvLaZTGdQPAtO3POyl51F/MeDFme/OK0NJ5i618xjCQ==", null, false, null, 1, false, "albusdumbledore" },
                    { 8, 0, "cf17686c-f5b8-4035-a2b6-49387b3a38fe", "lordvoldemort@email.com", false, false, null, "LORDVOLDEMORT@EMAIL.COM", null, "AQAAAAEAACcQAAAAEO2yGeDg3JAKcu029/kAhJafTpOPgjRqRL8337sRwUzEfKVI55tmEEDKERKqbMis7Q==", null, false, null, 1, false, "lordvoldemort" },
                    { 9, 0, "d1a79842-46e4-4104-b1c8-a35a83f43885", "dracomalfoy@email.com", false, false, null, "DRACOMALFOY@EMAIL.COM", null, "AQAAAAEAACcQAAAAEDLXDfXLzUYGGaa8w1Pgemqsoy/Q9aUMHkWmBx36z/j8KztwYJ/bNRfjsit/62L4wA==", null, false, null, 1, false, "dracomalfoy" },
                    { 10, 0, "f9657099-0f43-4325-90d8-0953b98bd7fd", "siriusblack@email.com", false, false, null, "SIRIUSBLACK@EMAIL.COM", null, "AQAAAAEAACcQAAAAENXJbNwoYnEcR50ic7QWCjRFH6OIGbUeKFzC4sKidR3+Q0pAKB4c4Z90Ni3Yf011NA==", null, false, null, 1, false, "siriusblack" }
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
                columns: new[] { "RoleId", "UserId", "RoleId1", "UserId1" },
                values: new object[,]
                {
                    { 1, -1, null, null },
                    { 2, 1, null, null }
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
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

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
