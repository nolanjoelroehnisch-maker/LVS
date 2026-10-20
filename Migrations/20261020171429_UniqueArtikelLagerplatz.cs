using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LVS.Migrations
{
    /// <inheritdoc />
    public partial class UniqueArtikelLagerplatz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LagerplatzBestaende_ArtikelId",
                table: "LagerplatzBestaende");

            migrationBuilder.CreateIndex(
                name: "IX_LagerplatzBestaende_ArtikelId_LagerplatzId",
                table: "LagerplatzBestaende",
                columns: new[] { "ArtikelId", "LagerplatzId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LagerplatzBestaende_ArtikelId_LagerplatzId",
                table: "LagerplatzBestaende");

            migrationBuilder.CreateIndex(
                name: "IX_LagerplatzBestaende_ArtikelId",
                table: "LagerplatzBestaende",
                column: "ArtikelId");
        }
    }
}
