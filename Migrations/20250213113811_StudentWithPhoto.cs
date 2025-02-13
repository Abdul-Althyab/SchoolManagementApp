using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class StudentWithPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentPhoto",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentPhoto",
                table: "Students");
        }
    }
}
