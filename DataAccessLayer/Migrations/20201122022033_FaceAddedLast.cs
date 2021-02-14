using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FaceAddedLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "StudentFaces",
                newName: "StudentFaces",
                newSchema: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "StudentFaces",
                schema: "Admin",
                newName: "StudentFaces");
        }
    }
}
