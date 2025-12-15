using Microsoft.EntityFrameworkCore;
using SelfLearning.Domain.Entities;

namespace SelfLearning.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Train> Trains => Set<Train>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.TrainId);

            entity.HasIndex(e => e.TrainNo)
                  .IsUnique();

            entity.Property(e => e.LastUpdated)
                  .HasDefaultValueSql("now()");
        });
    }
}



