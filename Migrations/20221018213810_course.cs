using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearn.Migrations
{
    public partial class course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectCoID",
                schema: "Identity",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectCoID",
                schema: "Identity",
                table: "Courses");
        }
    }
}
