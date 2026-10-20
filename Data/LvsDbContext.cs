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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Lagerplatz gehört zu einem Lager
            modelBuilder.Entity<Lagerplatz>()
                .HasOne(lp => lp.Lager)
                .WithMany(l => l.Lagerplaetze)
                .HasForeignKey(lp => lp.LagerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Artikelbestand pro Lagerplatz
            modelBuilder.Entity<LagerplatzBestand>()
                .HasOne(b => b.Artikel)
                .WithMany(a => a.LagerplatzBestaende)
                .HasForeignKey(b => b.ArtikelId);

            modelBuilder.Entity<LagerplatzBestand>()
                .HasOne(b => b.Lagerplatz)
                .WithMany(lp => lp.LagerplatzBestaende)
                .HasForeignKey(b => b.LagerplatzId);

            // Wareneingang
            modelBuilder.Entity<Wareneingang>()
                .HasOne(w => w.Artikel)
                .WithMany()
                .HasForeignKey(w => w.ArtikelId);

            modelBuilder.Entity<Wareneingang>()
                .HasOne(w => w.Lagerplatz)
                .WithMany()
                .HasForeignKey(w => w.LagerplatzId);

            // Warenausgang
            modelBuilder.Entity<Warenausgang>()
                .HasOne(w => w.Artikel)
                .WithMany()
                .HasForeignKey(w => w.ArtikelId);

            modelBuilder.Entity<Warenausgang>()
                .HasOne(w => w.Lagerplatz)
                .WithMany()
                .HasForeignKey(w => w.LagerplatzId);

            // Lagerbewegung
            modelBuilder.Entity<Lagerbewegung>()
                .HasOne(b => b.Artikel)
                .WithMany()
                .HasForeignKey(b => b.ArtikelId);

            modelBuilder.Entity<Lagerbewegung>()
                .HasOne(b => b.Lagerplatz)
                .WithMany()
                .HasForeignKey(b => b.LagerplatzId);

            // Verdichtungsposition
            modelBuilder.Entity<VerdichtungsPosition>()
                .HasOne(p => p.Verdichtung)
                .WithMany(v => v.Positionen)
                .HasForeignKey(p => p.VerdichtungId);

            modelBuilder.Entity<VerdichtungsPosition>()
                .HasOne(p => p.Artikel)
                .WithMany()
                .HasForeignKey(p => p.ArtikelId);

            modelBuilder.Entity<LagerplatzBestand>()
                .HasIndex(b => new { b.ArtikelId, b.LagerplatzId })
                .IsUnique();
        }

    }
}