using Microsoft.EntityFrameworkCore;
using Orders.Domain;

namespace Shared.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Each module registers its own entity configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Order).Assembly);
    }
}
