using System;
using System.Linq;
using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var proprieties = entityType.ClrType.
                        GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));

                    foreach (var propriety in proprieties)
                    {
                        modelBuilder.Entity(entityType.Name)
                            .Property(propriety.Name)
                            .HasConversion<double>();
                    }
                }
            }
        }
    }
}
