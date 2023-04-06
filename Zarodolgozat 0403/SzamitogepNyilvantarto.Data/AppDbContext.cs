using Microsoft.EntityFrameworkCore;
using SzamitogepNyilvantarto.Data.Entities;

namespace SzamitogepNyilvantarto.Data;
public class AppDbContext:DbContext
{
    public DbSet<Allapot> Allapotok { get; set; }
    public DbSet<Hiba> Hibak { get; set; }
    public DbSet<Szamitogep> Szamitogepek { get; set; }

    public DbSet<Felhasznalo> Felhasznalok { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server = localhost\SQLEXPRESS; Database = SzamitogepDB; Trusted_Connection = True;TrustServerCertificate=True");
        //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SzamitogepDB;Trusted_Connection=True;TrustServerCertificate=True");
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Szamitogep>().HasOne(x => x.Allapot).WithMany(x=>x.Szamitogepek).OnDelete(DeleteBehavior.NoAction); 
        modelBuilder.Entity<Hiba>().HasOne(x=>x.HibasGep).WithMany(x=>x.Hibak).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Hiba>().HasOne(x=>x.CsereGep).WithMany(x=>x.Cserek).OnDelete(DeleteBehavior.NoAction);

        List<Allapot> allapotok = new List<Allapot>
        {
              new Allapot{Id=1, Elnevezes="Használatban" },
              new Allapot{Id=2, Elnevezes="Használatra kész" },
              new Allapot{Id=3, Elnevezes="Hibás" },
              new Allapot{Id=4, Elnevezes="Javítás alatt" },
              new Allapot{Id=5, Elnevezes="Leselejtezve" },
              new Allapot{Id=6, Elnevezes="Megoldódott"}
        };
        modelBuilder.Entity<Allapot>().HasData(allapotok);

        Felhasznalo felhasznalo = new Felhasznalo(1, "Admin", "Admin", "pdf");
        modelBuilder.Entity<Felhasznalo>().HasData(felhasznalo);
    }
}
