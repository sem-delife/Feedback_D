using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feedback_Application.Migrations
{
    /// <inheritdoc />
    public partial class VariableErgebnisseupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedbackID",
                table: "Variable_Ergebnisse",
                newName: "ErstellungsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ErstellungsID",
                table: "Variable_Ergebnisse",
                newName: "FeedbackID");
        }
    }
}
