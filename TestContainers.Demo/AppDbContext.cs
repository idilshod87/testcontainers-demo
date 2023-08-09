using Microsoft.EntityFrameworkCore;

namespace TestContainers.Demo;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>()
            .HasIndex(u => u.Id)
            .IsUnique();

        builder.Entity<Customer>()
            .Property(b => b.Address)
            .HasColumnType("jsonb");
    }

}
