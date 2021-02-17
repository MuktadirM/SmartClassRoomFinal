using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CourseFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Courses_CourseId",
                schema: "Lecturer",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_CourseId",
                schema: "Lecturer",
                table: "Attendances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Attendances_CourseId",
                schema: "Lecturer",
                table: "Attendances",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Courses_CourseId",
                schema: "Lecturer",
                table: "Attendances",
                column: "CourseId",
                principalSchema: "Admin",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
