using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class StudentFieldChangedNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JoinDate",
                schema: "Admin",
                table: "Students",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "Admin",
                table: "Students",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "AddedBy",
                schema: "Admin",
                table: "Students",
                newName: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                schema: "Admin",
                table: "Students",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "Admin",
                table: "Students",
                newName: "AddedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "Admin",
                table: "Students",
                newName: "JoinDate");
        }
    }
}
