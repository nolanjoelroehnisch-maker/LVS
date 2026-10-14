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
                    Passwort = table.Column<string>(type: "TEXT", nullable: false),
                    Rolle = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Vorname = table.Column<string>(type: "TEXT", nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", nullable: false),
                    Telefonnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Benutzerstatus = table.Column<string>(type: "TEXT", nullable: false),
                    LetzterLogin = table.Column<string>(type: "TEXT", nullable: false),
                    Erstellungsdatum = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "Lagerbewegungen",
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
                    table.PrimaryKey("PK_Lagerbewegungen", x => x.Id);
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
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Benutzer");

            migrationBuilder.DropTable(
                name: "Lager");

            migrationBuilder.DropTable(
                name: "Lagerbewegungen");

            migrationBuilder.DropTable(
                name: "Lagerplaetze");

            migrationBuilder.DropTable(
                name: "LagerplatzBestaende");

            migrationBuilder.DropTable(
                name: "Verdichtungen");

            migrationBuilder.DropTable(
                name: "VerdichtungsPositionen");

            migrationBuilder.DropTable(
                name: "Warenausgaenge");

            migrationBuilder.DropTable(
                name: "Wareneingaenge");
        }
    }
}
