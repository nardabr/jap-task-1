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
                name: "LectureEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkHours = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureEvents_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
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

            migrationBuilder.CreateTable(
                name: "StudentLectureEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DoneByCandidate = table.Column<int>(type: "int", nullable: false),
                    StatusByCandidate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLectureEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLectureEvents_LectureEvents_LectureEventId",
                        column: x => x.LectureEventId,
                        principalTable: "LectureEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLectureEvents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
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
                    { -1, 0, "2258de75-17f5-4079-b8d6-82fc66295532", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", null, "AQAAAAEAACcQAAAAEIvRzDSbotYps/ZZGK1PXNP/0DPcpBXDQH2VOlh7O8bqIO3TKIxIaCPHnRg8Fi1myQ==", null, false, null, 1, false, "admin" },
                    { 1, 0, "aaf5df25-597f-436d-9886-4d5a53903cc4", "adalovelace@email.com", false, false, null, "ADALOVELACE@EMAIL.COM", null, "AQAAAAEAACcQAAAAEO+R/iYbhUK29O4B3hwDiEW9QCZz85W+Ot0iNS6DsnXaHh4Re90Cgl1qb2oYAtZmRA==", null, false, null, 1, false, "adalovelace" },
                    { 2, 0, "490e8fc3-9783-4caa-b6be-59a8b82c08f5", "gracehopper@email.com", false, false, null, "GRACEHOPPER@EMAIL.COM", null, "AQAAAAEAACcQAAAAEOIHRaxFr/aQVSPVOpBKK/ok9X5D7v3FwaxzH/sb39OLHShgnjTkRq7TYrICRL02DQ==", null, false, null, 1, false, "gracehopper" },
                    { 3, 0, "87315885-be38-405f-803f-04eff98c0bea", "joanclarke@email.com", false, false, null, "JOANCLARKE@EMAIL.COM", null, "AQAAAAEAACcQAAAAEDLcXlP5eYfTc/kxt7v2WMX+auIYW2/cUs/QaZFbjqtQoZZaasAB4YWfST+XxI7VDA==", null, false, null, 1, false, "joanclarke" },
                    { 4, 0, "ab65257f-5a1b-4a73-b951-43347dcc5283", "harrypotter@email.com", false, false, null, "HARRYPOTTER@EMAIL.COM", null, "AQAAAAEAACcQAAAAEFgy/n7H+qx4CWl5i4aAOV7eN/v97rXnNPoLDSwuB/p/be6Lz3bbaIKc6YDmwDj29w==", null, false, null, 1, false, "harrypotter" },
                    { 5, 0, "4cb5204b-d3bb-4b13-a277-2681bdb1a738", "hermionegranger@email.com", false, false, null, "HERMIONEGRANGER@EMAIL.COM", null, "AQAAAAEAACcQAAAAELcUP0J+8CrLzP7AzQi2xB7gkmY1TueWQ21IP3s3SKGpE29N3gJJRwmdq2aXrUKoMg==", null, false, null, 1, false, "hermionegranger" },
                    { 6, 0, "fb199bfa-638e-4288-9693-1604c6196301", "ronweasley@email.com", false, false, null, "RONWEASLEY@EMAIL.COM", null, "AQAAAAEAACcQAAAAEAemH1Poj2oFkrUES3apcw867uK+wJSTm9ukv3qv5M0ehD0MqQdvQv2pBmmUZCKC5A==", null, false, null, 1, false, "ronweasley" },
                    { 7, 0, "bdb0aec3-709e-4df9-af68-62bc6c10784b", "albusdumbledore@email.com", false, false, null, "ALBUSDUMBLEDORE@EMAIL.COM", null, "AQAAAAEAACcQAAAAEJDf8rdT6aI+Sn23nZL82OwVdVEtrxspR8wpad+cfVMtDTxKg1wQ0Ug6FaKMcp9PGw==", null, false, null, 1, false, "albusdumbledore" },
                    { 8, 0, "65d9746f-0159-46dc-b56a-d84740045699", "lordvoldemort@email.com", false, false, null, "LORDVOLDEMORT@EMAIL.COM", null, "AQAAAAEAACcQAAAAEGFkbJZWlqcT8DX69qIhZG0PA071TKZk7hTjqVTE7NkuS/dTdR/KoNFxVjL2vXWRkQ==", null, false, null, 1, false, "lordvoldemort" },
                    { 9, 0, "9eb80103-0924-46ac-999a-1d24cfccc695", "dracomalfoy@email.com", false, false, null, "DRACOMALFOY@EMAIL.COM", null, "AQAAAAEAACcQAAAAEJokU8P0V/4NJ6duQB/ZRfCxQ3QW1SZT5TCNw+v+mT3RszjlgPOGyZeE34pVDlEbFA==", null, false, null, 1, false, "dracomalfoy" },
                    { 10, 0, "2a0188fe-ae95-4f35-9b93-1d9cb6323ec6", "siriusblack@email.com", false, false, null, "SIRIUSBLACK@EMAIL.COM", null, "AQAAAAEAACcQAAAAELsZzhD9kpvkkyJr6/sa9kSzKa0D2dDZUTvTsK49OVoffRCyPhMXg25c5bdE7FQ5Qg==", null, false, null, 1, false, "siriusblack" }
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
                table: "LectureEvents",
                columns: new[] { "Id", "Description", "EndDate", "Name", "OrderNumber", "ProgramId", "StartDate", "Type", "Url", "WorkHours" },
                values: new object[,]
                {
                    { 1, "This course will teach you React.js in a practice-oriented way, using all the latest patterns and best practices you need. You will learn all the key fundamentals as well as advanced concepts and related topics to turn you into a React.js developer.", new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udemy - React", 1, 1, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture", "https://www.udemy.com/course/react-the-complete-guide-incl-redux/?src=sac&kw=react", 40 },
                    { 2, "The .NET framework is getting better and better and more important in the web development world nowadays. Almost every request I get for new web development projects is asking for knowledge in .NET, including Web API and Entity Framework Core. So, knowing the fundamentals of back-end web development with .NET can be highly beneficial to your career. And that’s where this course comes in.", new DateTime(2022, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udemy - .Net Core", 2, 1, new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture", "https://www.udemy.com/course/net-core-31-web-api-entity-framework-core-jumpstart/", 20 },
                    { 3, "Goal of the project is to build JAP platform. The main idea is to build a platform where we could have evidence of students, selections and programs.", new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Project - Task", 3, 1, new DateTime(2022, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event", "https://www.udemy.com/", 40 },
                    { 4, "Edit completed assignment", new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task Refactoring", 4, 1, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event", "https://www.udemy.com/", 8 },
                    { 5, "2022 BEST job oriented Software Manual Testing course on real time Project+Interview ques+Resume Prep+ Lifetime Support", new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udemy - Software Testing", 1, 2, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture", "https://www.udemy.com/course/learn-software-testing-in-practical-become-a-qa-expert/?src=sac&kw=qa", 10 },
                    { 6, "Become a Master in Manual Testing QA with Live Testing Projects, AGILE, JIRA, 100+Interview Questions & Lifetime support", new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udemy - Manual Testing", 2, 2, new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture", "https://www.udemy.com/course/specialize-in-software-testing-with-real-examples-agile-jira/?src=sac&kw=qa", 10 },
                    { 7, "Goal of the project is to build JAP platform. The main idea is to build a platform where we could have evidence of students, selections and programs.", new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Project - Task", 3, 2, new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event", "https://www.udemy.com/", 40 },
                    { 8, "Edit completed assignment", new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task Refactoring", 4, 2, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event", "https://www.udemy.com/", 8 },
                    { 9, "Begin DevOps Career As an Absolute Beginner | Linux, AWS, Scripting, Jenkins, Ansible, Docker, K8s, N-Tier Projects", new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "DevOps Beginners to Advanced", 1, 3, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture", "https://www.udemy.com/course/decodingdevops/?src=sac&kw=devop", 50 },
                    { 10, "DevOps for Absolute Beginners: Azure DevOps, Docker, Kubernetes, Jenkins, Terraform, Ansible - AWS, Azure & Google Cloud", new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn DevOps", 2, 3, new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture", "https://www.udemy.com/course/devops-with-docker-kubernetes-and-azure-devops/?src=sac&kw=devop", 20 },
                    { 11, "Goal of the project is to build JAP platform. The main idea is to build a platform where we could have evidence of students, selections and programs.", new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Project - Task", 3, 3, new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event", "https://www.udemy.com/", 40 },
                    { 12, "Edit completed assignment", new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task Refactoring", 4, 3, new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event", "https://www.udemy.com/", 8 }
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

            migrationBuilder.InsertData(
                table: "StudentLectureEvents",
                columns: new[] { "Id", "DoneByCandidate", "LectureEventId", "StatusByCandidate", "StudentId" },
                values: new object[,]
                {
                    { 1, 100, 1, "Done", 1 },
                    { 2, 80, 2, "In Progress", 1 },
                    { 3, 10, 3, "Started", 1 },
                    { 4, 0, 4, "Not Started", 1 },
                    { 5, 100, 5, "Done", 2 },
                    { 6, 80, 6, "In Progress", 2 },
                    { 7, 10, 7, "Started", 2 },
                    { 8, 0, 8, "Not Started", 2 },
                    { 9, 100, 9, "Done", 3 },
                    { 10, 80, 10, "In Progress", 3 },
                    { 11, 10, 11, "Started", 3 },
                    { 12, 0, 12, "Not Started", 3 },
                    { 13, 100, 1, "Done", 4 },
                    { 14, 80, 2, "In Progress", 4 },
                    { 15, 10, 3, "Started", 4 },
                    { 16, 0, 4, "Not Started", 4 },
                    { 17, 100, 5, "Done", 5 },
                    { 18, 80, 6, "In Progress", 5 },
                    { 19, 10, 7, "Started", 5 },
                    { 20, 0, 8, "Not Started", 5 },
                    { 21, 100, 9, "Done", 6 },
                    { 22, 80, 10, "In Progress", 6 },
                    { 23, 10, 11, "Started", 6 },
                    { 24, 0, 12, "Not Started", 6 },
                    { 25, 100, 1, "Done", 7 },
                    { 26, 80, 2, "In Progress", 7 },
                    { 27, 10, 3, "Started", 7 },
                    { 28, 0, 4, "Not Started", 7 },
                    { 29, 100, 5, "Done", 8 },
                    { 30, 80, 6, "In Progress", 8 },
                    { 31, 10, 7, "Started", 8 },
                    { 32, 0, 8, "Not Started", 8 },
                    { 33, 100, 9, "Done", 9 },
                    { 34, 80, 10, "In Progress", 9 },
                    { 35, 10, 11, "Started", 9 },
                    { 36, 0, 12, "Not Started", 9 },
                    { 37, 100, 1, "Done", 10 },
                    { 38, 80, 2, "In Progress", 10 },
                    { 39, 10, 3, "Started", 10 },
                    { 40, 0, 4, "Not Started", 10 }
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
                name: "IX_LectureEvents_ProgramId",
                table: "LectureEvents",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_ProgramId",
                table: "Selections",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_SelectionStatusId",
                table: "Selections",
                column: "SelectionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLectureEvents_LectureEventId",
                table: "StudentLectureEvents",
                column: "LectureEventId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLectureEvents_StudentId",
                table: "StudentLectureEvents",
                column: "StudentId");

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
                name: "StudentLectureEvents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LectureEvents");

            migrationBuilder.DropTable(
                name: "Students");

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
