using Microsoft.EntityFrameworkCore;
using LVS.Models;

namespace LVS.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
            : base(options)
        {

        }

        public DbSet<Article> Article { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }
        public DbSet<LocationStock> LocationStocks { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public DbSet<GoodsIssue> GoodsIssues { get; set; }
        public DbSet<Consolidation> Consolidations { get; set; }
        public DbSet<ConsolidationPosition> ConsolidationPositions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // StorageLocation gehört zu einem Warehouse
            modelBuilder.Entity<StorageLocation>()
                .HasOne(lp => lp.Warehouse)
                .WithMany(l => l.StorageLocations)
                .HasForeignKey(lp => lp.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Articlebestand pro StorageLocation
            modelBuilder.Entity<LocationStock>()
                .HasOne(b => b.Article)
                .WithMany(a => a.LocationStocks)
                .HasForeignKey(b => b.ArticleId);

            modelBuilder.Entity<LocationStock>()
                .HasOne(b => b.StorageLocation)
                .WithMany(lp => lp.LocationStocks)
                .HasForeignKey(b => b.StorageLocationId);

            // GoodsReceipt
            modelBuilder.Entity<GoodsReceipt>()
                .HasOne(w => w.Article)
                .WithMany()
                .HasForeignKey(w => w.ArticleId);

            modelBuilder.Entity<GoodsReceipt>()
                .HasOne(w => w.StorageLocation)
                .WithMany()
                .HasForeignKey(w => w.StorageLocationId);

            // GoodsIssue
            modelBuilder.Entity<GoodsIssue>()
                .HasOne(w => w.Article)
                .WithMany()
                .HasForeignKey(w => w.ArticleId);

            modelBuilder.Entity<GoodsIssue>()
                .HasOne(w => w.StorageLocation)
                .WithMany()
                .HasForeignKey(w => w.StorageLocationId);

            // StockMovement
            modelBuilder.Entity<StockMovement>()
                .HasOne(b => b.Article)
                .WithMany()
                .HasForeignKey(b => b.ArticleId);

            modelBuilder.Entity<StockMovement>()
                .HasOne(b => b.StorageLocation)
                .WithMany()
                .HasForeignKey(b => b.StorageLocationId);

            // Consolidationsposition
            modelBuilder.Entity<ConsolidationPosition>()
                .HasOne(p => p.Consolidation)
                .WithMany(v => v.Positions)
                .HasForeignKey(p => p.ConsolidationId);

            modelBuilder.Entity<ConsolidationPosition>()
                .HasOne(p => p.Article)
                .WithMany()
                .HasForeignKey(p => p.ArticleId);

            modelBuilder.Entity<LocationStock>()
                .HasIndex(b => new { b.ArticleId, b.StorageLocationId })
                .IsUnique();
        }

    }
}