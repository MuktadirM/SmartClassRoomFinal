using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FaceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendProcess_Section_AttendProcessId",
                schema: "Admin",
                table: "AttendProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Section_SectionId",
                schema: "Admin",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Courses_CourseId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Lecturers_LecturerId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "Sections",
                newSchema: "Admin");

            migrationBuilder.RenameIndex(
                name: "IX_Section_LecturerId",
                schema: "Admin",
                table: "Sections",
                newName: "IX_Sections_LecturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_CourseId",
                schema: "Admin",
                table: "Sections",
                newName: "IX_Sections_CourseId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Lecturer",
                table: "Attendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "Lecturer",
                table: "Attendances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "Lecturer",
                table: "Attendances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Lecturer",
                table: "Attendances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                schema: "Lecturer",
                table: "Attendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                schema: "Admin",
                table: "Sections",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentFaces",
                columns: table => new
                {
                    StudentFaceDataId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFaces", x => x.StudentFaceDataId);
                    table.ForeignKey(
                        name: "FK_StudentFaces_Students_StudentFaceDataId",
                        column: x => x.StudentFaceDataId,
                        principalSchema: "Admin",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AttendProcess_Sections_AttendProcessId",
                schema: "Admin",
                table: "AttendProcess",
                column: "AttendProcessId",
                principalSchema: "Admin",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Sections_SectionId",
                schema: "Admin",
                table: "Registrations",
                column: "SectionId",
                principalSchema: "Admin",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Courses_CourseId",
                schema: "Admin",
                table: "Sections",
                column: "CourseId",
                principalSchema: "Admin",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Lecturers_LecturerId",
                schema: "Admin",
                table: "Sections",
                column: "LecturerId",
                principalSchema: "Admin",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendProcess_Sections_AttendProcessId",
                schema: "Admin",
                table: "AttendProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Sections_SectionId",
                schema: "Admin",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Courses_CourseId",
                schema: "Admin",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Lecturers_LecturerId",
                schema: "Admin",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "StudentFaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                schema: "Admin",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Lecturer",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Lecturer",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "Lecturer",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Lecturer",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                schema: "Lecturer",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Sections",
                schema: "Admin",
                newName: "Section");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_LecturerId",
                table: "Section",
                newName: "IX_Section_LecturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_CourseId",
                table: "Section",
                newName: "IX_Section_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendProcess_Section_AttendProcessId",
                schema: "Admin",
                table: "AttendProcess",
                column: "AttendProcessId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Section_SectionId",
                schema: "Admin",
                table: "Registrations",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Courses_CourseId",
                table: "Section",
                column: "CourseId",
                principalSchema: "Admin",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Lecturers_LecturerId",
                table: "Section",
                column: "LecturerId",
                principalSchema: "Admin",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
