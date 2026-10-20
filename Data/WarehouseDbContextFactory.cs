using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LVS.Data
{
    public class WarehouseDbContextFactory
        : IDesignTimeDbContextFactory<WarehouseDbContext>
    {
        public WarehouseDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<WarehouseDbContext>();
            options.UseSqlite("Data Source=Lvs.db");

            return new WarehouseDbContext(options.Options);
        }
    }
}


/*
Die Migration konnte zunächst nicht erstellt werden, da EF Core den
WarehouseDbContext zur Designzeit nicht initialisieren konnte.

Fehlermeldung:
Unable to resolve service for type
'DbContextOptions<WarehouseDbContext>'.

Lösung:
Eine WarehouseDbContextFactory mit IDesignTimeDbContextFactory erstellt,
damit EF Core weiss, wie der DbContext für Migrationen erzeugt wird.
*/