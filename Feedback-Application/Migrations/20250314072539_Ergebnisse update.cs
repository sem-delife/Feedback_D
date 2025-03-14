using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feedback_Application.Migrations
{
    /// <inheritdoc />
    public partial class Ergebnisseupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErstellungsID",
                table: "Ergebnisse",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErstellungsID",
                table: "Ergebnisse");
        }
    }
}
