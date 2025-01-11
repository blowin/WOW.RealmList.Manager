using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WOW.RealmList.Manager.Domain;

namespace WOW.RealmList.Manager.Sqlite.Migrations;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=content.db", b => b.MigrationsAssembly(typeof(AppDbContextFactory).Assembly.FullName));
        return new AppDbContext(builder.Options);
    }
}