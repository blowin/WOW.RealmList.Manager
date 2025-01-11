using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WOW.RealmList.Manager.Domain;

public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at").IsRequired();
        ConfigureCore(builder);
    }

    protected abstract void ConfigureCore(EntityTypeBuilder<TEntity> builder);
}

public sealed class AccountConfiguration : EntityConfiguration<Account>
{
    protected override void ConfigureCore(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("account");
        
        builder.Property(e => e.Login).HasColumnName("login").HasMaxLength(128).IsRequired();
        builder.Property(e => e.Password).HasColumnName("password").HasMaxLength(1024);
        builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(1024);
    }
}

public sealed class RealmListConfiguration : EntityConfiguration<RealmList>
{
    protected override void ConfigureCore(EntityTypeBuilder<RealmList> builder)
    {
        builder.ToTable("realm_list");
        
        builder.Property(e => e.Name).HasColumnName("login").HasMaxLength(256).IsRequired();
        builder.Property(e => e.Address).HasColumnName("address").HasMaxLength(256).IsRequired();
        builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(1024);
        builder.HasMany(e => e.Accounts)
            .WithOne()
            .IsRequired()
            .HasForeignKey(e => e.RealmListId);
    }
}

public sealed class ServerConfiguration : EntityConfiguration<Server>
{
    protected override void ConfigureCore(EntityTypeBuilder<Server> builder)
    {
        builder.ToTable("server");
        
        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(128).IsRequired();
        builder.HasMany(e => e.Realmlists)
            .WithOne()
            .IsRequired()
            .HasForeignKey(e => e.ServerId);
    }
}
