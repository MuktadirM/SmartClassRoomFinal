using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class StudentFieldChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Admin",
                table: "Students",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Admin",
                table: "Students",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddedBy",
                schema: "Admin",
                table: "Students",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FaceAdded",
                schema: "Admin",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Admin",
                table: "Students",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceAdded",
                schema: "Admin",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "Admin",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "IsDeleted",
                schema: "Admin",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                schema: "Admin",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "AddedBy",
                schema: "Admin",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);
        }
    }
}
