using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Examination_Program_MVC.Migrations
{
    /// <inheritdoc />
    public partial class TablesSeedWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudentNumber",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "StudentNumber",
                table: "Exams",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_StudentNumber",
                table: "Exams",
                newName: "IX_Exams_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "StudentNumber",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Class", "CourseCode", "CourseName", "TeacherFirstName", "TeacherLastName" },
                values: new object[,]
                {
                    { 1, 9, "MTH", "Mathematics", "John", "Doe" },
                    { 2, 9, "SCI", "Science", "Jane", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class", "FirstName", "LastName", "StudentNumber" },
                values: new object[,]
                {
                    { 1, 9, "Alice", "Johnson", 1001 },
                    { 2, 9, "Bob", "Williams", 1002 }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CourseId", "ExamDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 2, 2, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Students_StudentId",
                table: "Exams",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudentId",
                table: "Exams");

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Exams",
                newName: "StudentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_StudentId",
                table: "Exams",
                newName: "IX_Exams_StudentNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Students_StudentNumber",
                table: "Exams",
                column: "StudentNumber",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
