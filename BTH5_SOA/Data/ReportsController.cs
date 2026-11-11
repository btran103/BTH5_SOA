using Microsoft.EntityFrameworkCore;
using BTH5_ReportingService.Models;

namespace BTH5_ReportingService.Data;

public class ReportDbContext : DbContext
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProductReport> Products => Set<ProductReport>();
    public DbSet<OrderReport> Orders => Set<OrderReport>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductReport>(entity =>
        {
            entity.Property(e => e.UnitCost).HasPrecision(18, 2);
            entity.Property(e => e.SellingPrice).HasPrecision(18, 2);
        });

        modelBuilder.Entity<OrderReport>(entity =>
        {
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
            entity.Property(e => e.UnitCost).HasPrecision(18, 2);
            entity.Property(e => e.OtherCost).HasPrecision(18, 2);
        });
    }
}