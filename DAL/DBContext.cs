using Microsoft.EntityFrameworkCore;
using Task_7.Models;

namespace Task_7.DAL;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<PC> PCs { get; set; } = null!;
    public DbSet<Component> Components { get; set; } = null!;
    public DbSet<ComponentType> ComponentTypes { get; set; } = null!;
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; } = null!;
    public DbSet<PCComponent> PCComponents { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=Task_7;User Id=Admin");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PCComponent>()
        .HasKey(pc => new { pc.PCId, pc.ComponentCode });

        // random generated data to test
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" },
            new ComponentType { Id = 4, Abbreviation = "SSD", Name = "Solid State Drive" }
        );

        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "Intel", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturer { Id = 2, Abbreviation = "ASUS", FullName = "ASUSTeK Computer Inc.", FoundationDate = new DateOnly(1989, 6, 2) },
            new ComponentManufacturer { Id = 3, Abbreviation = "Samsung", FullName = "Samsung Electronics", FoundationDate = new DateOnly(1938, 3, 1) },
            new ComponentManufacturer { Id = 4, Abbreviation = "Corsair", FullName = "Corsair Components, Inc.", FoundationDate = new DateOnly(1994, 2, 1) }
        );

        modelBuilder.Entity<Component>().HasData(
            new Component { Code = "I9-14900K ", Name = "Intel Core i9-14900K", Description = "Next-gen high-performance CPU", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component { Code = "NV4090XTX ", Name = "NVIDIA GeForce RTX 4090 XTX", Description = "Flagship GPU for gaming and compute", ComponentManufacturersId = 3, ComponentTypesId = 2 },
            new Component { Code = "DDR5-64GB ", Name = "64GB DDR5 Kit", Description = "High-capacity DDR5 memory kit", ComponentManufacturersId = 4, ComponentTypesId = 3 },
            new Component { Code = "SAMS-1TB  ", Name = "Samsung NVMe 1TB", Description = "Fast NVMe SSD, 1TB", ComponentManufacturersId = 3, ComponentTypesId = 4 }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC { Id = 1, Name = "Falcon Gaming", Weight = 9.5, Warranty = 36, CreatedAt = new DateTime(2026, 1, 20, 10, 0, 0), Stock = 6 },
            new PC { Id = 2, Name = "Slim Business", Weight = 3.1, Warranty = 24, CreatedAt = new DateTime(2025, 11, 5, 8, 30, 0), Stock = 20 },
            new PC { Id = 3, Name = "Render Pro", Weight = 19.7, Warranty = 48, CreatedAt = new DateTime(2026, 2, 12, 14, 15, 0), Stock = 2 }
        );

        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "I9-14900K ", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "NV4090XTX ", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "DDR5-64GB ", Amount = 2 },

            new PCComponent { PCId = 2, ComponentCode = "DDR5-64GB ", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "SAMS-1TB  ", Amount = 1 },

            new PCComponent { PCId = 3, ComponentCode = "I9-14900K ", Amount = 2 },
            new PCComponent { PCId = 3, ComponentCode = "NV4090XTX ", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "SAMS-1TB  ", Amount = 2 }
        );
    }
}