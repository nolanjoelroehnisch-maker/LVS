using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LVS.Data
{
    public class LvsDbContextFactory
        : IDesignTimeDbContextFactory<LvsDbContext>
    {
        public LvsDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<LvsDbContext>();
            options.UseSqlite("Data Source=Lvs.db");

            return new LvsDbContext(options.Options);
        }
    }
}


/*
Die Migration konnte zunächst nicht erstellt werden, da EF Core den
LvsDbContext zur Designzeit nicht initialisieren konnte.

Fehlermeldung:
Unable to resolve service for type
'DbContextOptions<LvsDbContext>'.

Lösung:
Eine LvsDbContextFactory mit IDesignTimeDbContextFactory erstellt,
damit EF Core weiss, wie der DbContext für Migrationen erzeugt wird.
*/