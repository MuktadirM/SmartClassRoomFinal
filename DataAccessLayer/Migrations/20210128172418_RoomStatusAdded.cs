using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class RoomStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageInfo_StudentFaces_StudentFaceId",
                schema: "Student",
                table: "StorageInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentFaces",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "Admin",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "Admin",
                table: "StudentFaces",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentFaces",
                schema: "Admin",
                table: "StudentFaces",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RoomStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoomBookedBy = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    RoomStatusType = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentFaces_StudentFaceDataId",
                schema: "Admin",
                table: "StudentFaces",
                column: "StudentFaceDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageInfo_StudentFaces_StudentFaceId",
                schema: "Student",
                table: "StorageInfo",
                column: "StudentFaceId",
                principalSchema: "Admin",
                principalTable: "StudentFaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageInfo_StudentFaces_StudentFaceId",
                schema: "Student",
                table: "StorageInfo");

            migrationBuilder.DropTable(
                name: "RoomStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentFaces",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.DropIndex(
                name: "IX_StudentFaces_StudentFaceDataId",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "Admin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Admin",
                table: "StudentFaces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentFaces",
                schema: "Admin",
                table: "StudentFaces",
                column: "StudentFaceDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageInfo_StudentFaces_StudentFaceId",
                schema: "Student",
                table: "StorageInfo",
                column: "StudentFaceId",
                principalSchema: "Admin",
                principalTable: "StudentFaces",
                principalColumn: "StudentFaceDataId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
