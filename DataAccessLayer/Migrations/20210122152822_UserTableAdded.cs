using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UserTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins",
                schema: "Admin");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "Admin",
                table: "Lecturers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_UserId",
                schema: "Admin",
                table: "Lecturers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Users_UserId",
                schema: "Admin",
                table: "Lecturers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Users_UserId",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_UserId",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Admin",
                table: "Lecturers");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "Admin",
                table: "Lecturers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Admin",
                table: "Lecturers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Admin",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Admin",
                table: "Lecturers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                schema: "Admin",
                table: "Lecturers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "Lecturers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "Admin",
                table: "Lecturers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "Admin",
                table: "Lecturers",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admins",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });
        }
    }
}
