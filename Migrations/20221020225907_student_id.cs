using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearn.Migrations
{
    public partial class student_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Identity",
                table: "Submissions_Students",
                newName: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentID",
                schema: "Identity",
                table: "Submissions_Students",
                newName: "Id");
        }
    }
}
