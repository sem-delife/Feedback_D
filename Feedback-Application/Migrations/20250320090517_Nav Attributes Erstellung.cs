using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feedback_Application.Migrations
{
    /// <inheritdoc />
    public partial class NavAttributesErstellung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Erstellung_AbteilungsID",
                table: "Erstellung",
                column: "AbteilungsID");

            migrationBuilder.CreateIndex(
                name: "IX_Erstellung_FachID",
                table: "Erstellung",
                column: "FachID");

            migrationBuilder.CreateIndex(
                name: "IX_Erstellung_KlassenID",
                table: "Erstellung",
                column: "KlassenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Erstellung_Abteilung_AbteilungsID",
                table: "Erstellung",
                column: "AbteilungsID",
                principalTable: "Abteilung",
                principalColumn: "AbteilungsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Erstellung_Fach_FachID",
                table: "Erstellung",
                column: "FachID",
                principalTable: "Fach",
                principalColumn: "FachID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Erstellung_Klassen_KlassenID",
                table: "Erstellung",
                column: "KlassenID",
                principalTable: "Klassen",
                principalColumn: "KlassenID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Erstellung_Abteilung_AbteilungsID",
                table: "Erstellung");

            migrationBuilder.DropForeignKey(
                name: "FK_Erstellung_Fach_FachID",
                table: "Erstellung");

            migrationBuilder.DropForeignKey(
                name: "FK_Erstellung_Klassen_KlassenID",
                table: "Erstellung");

            migrationBuilder.DropIndex(
                name: "IX_Erstellung_AbteilungsID",
                table: "Erstellung");

            migrationBuilder.DropIndex(
                name: "IX_Erstellung_FachID",
                table: "Erstellung");

            migrationBuilder.DropIndex(
                name: "IX_Erstellung_KlassenID",
                table: "Erstellung");
        }
    }
}
