using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LVS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Artikelnummer = table.Column<int>(type: "INTEGER", nullable: false),
                    Artikelbezeichnung = table.Column<string>(type: "TEXT", nullable: false),
                    Einheit = table.Column<string>(type: "TEXT", nullable: false),
                    Bestand = table.Column<int>(type: "INTEGER", nullable: false),
                    Mindestbestand = table.Column<int>(type: "INTEGER", nullable: false),
                    Hoechstbestand = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Benutzer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Benutzername = table.Column<string>(type: "TEXT", nullable: false),
                    PasswortHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswortSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Rolle = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Vorname = table.Column<string>(type: "TEXT", nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", nullable: false),
                    Telefonnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Benutzerstatus = table.Column<string>(type: "TEXT", nullable: false),
                    LetzterLogin = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Erstellungsdatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Berechtigungen = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LagerNummer = table.Column<string>(type: "TEXT", nullable: false),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verdichtungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verdichtungen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lagerplaetze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lagerplatznummer = table.Column<string>(type: "TEXT", nullable: false),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: false),
                    Kapazitaet = table.Column<int>(type: "INTEGER", nullable: false),
                    LagerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerplaetze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lagerplaetze_Lager_LagerId",
                        column: x => x.LagerId,
                        principalTable: "Lager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VerdichtungsPositionen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VerdichtungId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtikelId = table.Column<int>(type: "INTEGER", nullable: false),
                    Menge = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerdichtungsPositionen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerdichtungsPositionen_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerdichtungsPositionen_Verdichtungen_VerdichtungId",
                        column: x => x.VerdichtungId,
                        principalTable: "Verdichtungen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lagerbewegungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelId = table.Column<int>(type: "INTEGER", nullable: false),
                    LagerplatzId = table.Column<int>(type: "INTEGER", nullable: false),
                    Menge = table.Column<int>(type: "INTEGER", nullable: false),
                    Zeitpunkt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Bewegungsart = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerbewegungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lagerbewegungen_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lagerbewegungen_Lagerplaetze_LagerplatzId",
                        column: x => x.LagerplatzId,
                        principalTable: "Lagerplaetze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LagerplatzBestaende",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelId = table.Column<int>(type: "INTEGER", nullable: false),
                    LagerplatzId = table.Column<int>(type: "INTEGER", nullable: false),
                    Menge = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LagerplatzBestaende", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LagerplatzBestaende_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LagerplatzBestaende_Lagerplaetze_LagerplatzId",
                        column: x => x.LagerplatzId,
                        principalTable: "Lagerplaetze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warenausgaenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelId = table.Column<int>(type: "INTEGER", nullable: false),
                    LagerplatzId = table.Column<int>(type: "INTEGER", nullable: false),
                    Menge = table.Column<int>(type: "INTEGER", nullable: false),
                    SendungsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warenausgaenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warenausgaenge_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Warenausgaenge_Lagerplaetze_LagerplatzId",
                        column: x => x.LagerplatzId,
                        principalTable: "Lagerplaetze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wareneingaenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelId = table.Column<int>(type: "INTEGER", nullable: false),
                    LagerplatzId = table.Column<int>(type: "INTEGER", nullable: false),
                    Menge = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wareneingaenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wareneingaenge_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wareneingaenge_Lagerplaetze_LagerplatzId",
                        column: x => x.LagerplatzId,
                        principalTable: "Lagerplaetze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lagerbewegungen_ArtikelId",
                table: "Lagerbewegungen",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerbewegungen_LagerplatzId",
                table: "Lagerbewegungen",
                column: "LagerplatzId");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerplaetze_LagerId",
                table: "Lagerplaetze",
                column: "LagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LagerplatzBestaende_ArtikelId",
                table: "LagerplatzBestaende",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_LagerplatzBestaende_LagerplatzId",
                table: "LagerplatzBestaende",
                column: "LagerplatzId");

            migrationBuilder.CreateIndex(
                name: "IX_VerdichtungsPositionen_ArtikelId",
                table: "VerdichtungsPositionen",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_VerdichtungsPositionen_VerdichtungId",
                table: "VerdichtungsPositionen",
                column: "VerdichtungId");

            migrationBuilder.CreateIndex(
                name: "IX_Warenausgaenge_ArtikelId",
                table: "Warenausgaenge",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_Warenausgaenge_LagerplatzId",
                table: "Warenausgaenge",
                column: "LagerplatzId");

            migrationBuilder.CreateIndex(
                name: "IX_Wareneingaenge_ArtikelId",
                table: "Wareneingaenge",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_Wareneingaenge_LagerplatzId",
                table: "Wareneingaenge",
                column: "LagerplatzId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Benutzer");

            migrationBuilder.DropTable(
                name: "Lagerbewegungen");

            migrationBuilder.DropTable(
                name: "LagerplatzBestaende");

            migrationBuilder.DropTable(
                name: "VerdichtungsPositionen");

            migrationBuilder.DropTable(
                name: "Warenausgaenge");

            migrationBuilder.DropTable(
                name: "Wareneingaenge");

            migrationBuilder.DropTable(
                name: "Verdichtungen");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Lagerplaetze");

            migrationBuilder.DropTable(
                name: "Lager");
        }
    }
}
