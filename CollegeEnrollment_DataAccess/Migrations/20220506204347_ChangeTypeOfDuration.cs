using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeEnrollment_DataAccess.Migrations
{
    public partial class ChangeTypeOfDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Majors",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Majors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Majors",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Majors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
