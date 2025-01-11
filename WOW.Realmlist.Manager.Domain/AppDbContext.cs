using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;

namespace WOW.RealmList.Manager.Domain;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        SavingChanges += OnSavingChanges;
    }

    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<Server> Servers { get; set; }
    
    public DbSet<RealmList> RealmLists { get; set; }

    /// <summary>
    /// normal system clock with precision in seconds.
    /// </summary>
    public ISystemClock Clock { get; set; } = new SystemClock();

    private void OnSavingChanges(object? sender, SavingChangesEventArgs e)
    {
        var now = Clock.UtcNow.UtcDateTime;
        foreach (var entity in ChangeTracker.Entries<Entity>())
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    if (entity.Entity.CreatedAt == default)
                    {
                        entity.Entity.CreatedAt = now;
                    }

                    entity.Entity.UpdatedAt = now;
                    break;
                case EntityState.Modified:
                    entity.Entity.UpdatedAt = now;
                    break;
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}