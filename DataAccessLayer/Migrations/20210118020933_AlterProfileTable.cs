using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AlterProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Student");

            migrationBuilder.AddColumn<string>(
                name: "ContainerName",
                schema: "Admin",
                table: "StudentFaces",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                schema: "Admin",
                table: "StudentFaces",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Admin",
                table: "StudentFaces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrained",
                schema: "Admin",
                table: "StudentFaces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfImage",
                schema: "Admin",
                table: "StudentFaces",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "Admin",
                table: "Lecturers",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "Admin",
                table: "Admins",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StorageInfo",
                schema: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFaceId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageInfo_StudentFaces_StudentFaceId",
                        column: x => x.StudentFaceId,
                        principalSchema: "Admin",
                        principalTable: "StudentFaces",
                        principalColumn: "StudentFaceDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StorageInfo_StudentFaceId",
                schema: "Student",
                table: "StorageInfo",
                column: "StudentFaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StorageInfo",
                schema: "Student");

            migrationBuilder.DropColumn(
                name: "ContainerName",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.DropColumn(
                name: "GroupName",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.DropColumn(
                name: "IsTrained",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.DropColumn(
                name: "NumberOfImage",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Admin",
                table: "Lecturers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Admin",
                table: "Admins",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }
    }
}
