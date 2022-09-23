using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    public partial class CommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudentStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SelectionStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Selections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                    table.ForeignKey(
                        name: "FK_Comments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 190, 241, 147, 89, 50, 236, 222, 200, 162, 18, 27, 212, 182, 242, 32, 1, 42, 105, 68, 222, 158, 38, 78, 133, 175, 214, 247, 80, 146, 157, 226, 106, 191, 92, 90, 119, 198, 173, 170, 164, 140, 34, 130, 207, 75, 220, 80, 238, 11, 205, 52, 60, 212, 94, 131, 211, 232, 174, 254, 127, 74, 234, 186, 179 }, new byte[] { 106, 42, 83, 87, 13, 176, 199, 28, 196, 170, 58, 56, 115, 30, 215, 143, 77, 252, 213, 22, 247, 60, 3, 214, 52, 179, 108, 225, 21, 179, 45, 252, 116, 219, 245, 134, 202, 95, 81, 183, 83, 91, 152, 249, 22, 139, 60, 75, 186, 139, 60, 220, 165, 198, 33, 51, 74, 13, 19, 242, 140, 123, 32, 187, 215, 18, 252, 251, 234, 159, 0, 219, 105, 215, 28, 224, 234, 55, 98, 193, 158, 103, 225, 41, 207, 20, 215, 39, 133, 138, 210, 235, 143, 181, 240, 0, 2, 88, 79, 39, 150, 128, 10, 25, 138, 239, 85, 100, 214, 154, 45, 181, 185, 39, 119, 138, 175, 251, 181, 172, 248, 198, 168, 174, 181, 93, 82, 46 } });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StudentId",
                table: "Comments",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudentStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SelectionStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Selections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 108, 149, 195, 204, 12, 55, 56, 5, 59, 100, 136, 231, 49, 90, 178, 60, 230, 126, 224, 249, 11, 171, 223, 5, 46, 144, 149, 144, 213, 170, 23, 38, 104, 206, 208, 230, 203, 218, 228, 240, 238, 232, 127, 243, 50, 158, 114, 134, 134, 58, 95, 136, 3, 207, 144, 231, 207, 129, 191, 60, 195, 220, 224, 152 }, new byte[] { 118, 38, 121, 221, 13, 47, 127, 61, 124, 120, 94, 6, 4, 253, 186, 241, 204, 41, 32, 155, 217, 87, 50, 49, 253, 59, 150, 132, 181, 76, 212, 242, 115, 42, 90, 176, 58, 209, 161, 37, 84, 76, 62, 21, 42, 65, 73, 95, 152, 167, 214, 151, 229, 241, 236, 183, 46, 125, 152, 188, 99, 35, 203, 153, 81, 106, 143, 122, 109, 118, 191, 47, 165, 141, 234, 228, 37, 134, 67, 127, 241, 173, 168, 227, 87, 106, 12, 42, 117, 26, 251, 7, 52, 90, 208, 23, 64, 102, 238, 18, 147, 109, 105, 145, 164, 8, 6, 99, 15, 134, 93, 22, 2, 175, 39, 27, 60, 53, 71, 18, 172, 193, 127, 187, 53, 251, 39, 121 } });
        }
    }
}
