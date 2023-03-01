using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Compnay.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Company.Domain.Entities.Company> Companies { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public BaseDbContext(DbContextOptions contextOptions,IConfiguration configuration):base(contextOptions)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(u =>
        {
            u.ToTable("Products").HasKey(k=>k.Id);
            u.Property( p=> p.Id).HasColumnName("ProductId");
            u.Property(p => p.CompanyId).HasColumnName("CompanyId");
            u.Property(p => p.Price).HasColumnName("Price");
            u.Property(p => p.Stock).HasColumnName("Stock");
            u.Property(p => p.ProductName).HasColumnName("ProductName");
            u.HasOne(p=>p.Company);
        });

        modelBuilder.Entity<Order>(u =>
        {
            u.ToTable("Orders").HasKey(k => k.Id);
            u.Property(p => p.Id).HasColumnName("OrderId");
            u.Property(p => p.CustomerName).HasColumnName("CustomerName");
            u.Property(p => p.CompanyId).HasColumnName("CompanyId");
            u.Property(p => p.OrderDate).HasColumnName("OrderDate");
            u.Property(p => p.ProductId).HasColumnName("ProductId");
            u.HasOne(p => p.Product);
            u.HasOne(p => p.Company);
        });

        modelBuilder.Entity<Company.Domain.Entities.Company>(u =>
        {
            u.ToTable("Companies").HasKey(k => k.Id);
            u.Property(p => p.Id).HasColumnName("CompanyId");
            u.Property(p => p.CompanyName).HasColumnName("CompanyName");
            u.Property(p => p.IsActive).HasColumnName("IsActive");
            u.Property(p => p.DateTimeStart).HasColumnName("StartTime");
            u.Property(p => p.DateTimeEnd).HasColumnName("EndTime");
            u.HasMany(p => p.Products);
        });
    }
}