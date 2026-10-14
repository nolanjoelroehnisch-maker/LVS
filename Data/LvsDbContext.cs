using Microsoft.EntityFrameworkCore;
using LVS.Models;

namespace LVS.Data
{
    public class LvsDbContext : DbContext
    {
        public LvsDbContext(DbContextOptions<LvsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Lager> Lager { get; set; }
        public DbSet<Lagerplatz> Lagerplaetze { get; set; }
        public DbSet<LagerplatzBestand> LagerplatzBestaende { get; set; }
        public DbSet<Lagerbewegung> Lagerbewegungen { get; set; }
        public DbSet<Wareneingang> Wareneingaenge { get; set; }
        public DbSet<Warenausgang> Warenausgaenge { get; set; }
        public DbSet<Verdichtung> Verdichtungen { get; set; }
        public DbSet<VerdichtungsPosition> VerdichtungsPositionen { get; set; }
    }
}