using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LVS.Migrations
{
    /// <inheritdoc />
    public partial class AddLagerRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lagerplaetze_LagerId",
                table: "Lagerplaetze",
                column: "LagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lagerplaetze_Lager_LagerId",
                table: "Lagerplaetze",
                column: "LagerId",
                principalTable: "Lager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lagerplaetze_Lager_LagerId",
                table: "Lagerplaetze");

            migrationBuilder.DropIndex(
                name: "IX_Lagerplaetze_LagerId",
                table: "Lagerplaetze");
        }
    }
}
