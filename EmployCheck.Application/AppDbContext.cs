using EmployCheck.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployCheck.Application;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Employment> Employment { get; set; }

    // Optional: Customize table configurations if needed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employment>()
            .ToTable("Employment")
            .HasKey(x => x.EmployeeId);
    }
}