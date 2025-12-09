using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Models;
using System.IO;

namespace WinFormsApp1.Data;

public class CarsDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<CarService> CarServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Use SQLite database file in the application directory
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CarsDB.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().ToTable("Cars");
        modelBuilder.Entity<Owner>().ToTable("Owners");
        modelBuilder.Entity<Service>().ToTable("Services");
        modelBuilder.Entity<CarService>().ToTable("CarServices");
        // SQLite uses CURRENT_TIMESTAMP instead of GETDATE()
        modelBuilder.Entity<CarService>().Property(t => t.DateOfService).HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<CarService>().HasKey(cs => new { cs.CarId, cs.ServiceId });
    }

    public void EnsureCreated()
    {
        Database.EnsureCreated();
        SeedServices();
    }

    private void SeedServices()
    {
        // Check if services already exist
        if (Services.Any())
            return;

        // Add 3 default services in Estonian
        Services.AddRange(new[]
        {
            new Service { Name = "Rehvide vahetamine", Price = 50.0f },
            new Service { Name = "Auto pesemine", Price = 20.0f },
            new Service { Name = "Õlivahetus", Price = 30.0f }
        });

        SaveChanges();
    }
}
