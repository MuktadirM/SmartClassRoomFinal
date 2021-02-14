using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AlterRegistrationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Intake",
                schema: "Admin",
                table: "Registrations",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intake",
                schema: "Admin",
                table: "Registrations");
        }
    }
}
