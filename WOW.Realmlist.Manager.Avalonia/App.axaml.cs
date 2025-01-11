using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WOW.RealmList.Manager.Avalonia.ViewModels;
using WOW.RealmList.Manager.Avalonia.Views;
using WOW.RealmList.Manager.Domain;
using WOW.RealmList.Manager.Sqlite.Migrations;

namespace WOW.RealmList.Manager.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Register all the services needed for the application to run
        var collection = new ServiceCollection();
        collection.AddTransient<ServerViewModel>();
        collection.AddTransient<ServerView>();
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<MainWindow>();
        collection.AddTransient<AccountViewModel>();
        collection.AddTransient<AccountView>();
        collection.AddTransient<RealmListViewModel>();
        collection.AddTransient<RealmListView>();

        collection.AddDbContext<AppDbContext>(builder => 
            builder.UseSqlite("Data Source=content.db", optionsBuilder =>
                optionsBuilder.MigrationsAssembly(typeof(AppDbContextFactory).Assembly.FullName)));
        
        // Creates a ServiceProvider containing services from the provided IServiceCollection
        var services = collection.BuildServiceProvider();

        using (var serviceScope = services.CreateScope())
        {
            var appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
            appDbContext.Database.Migrate();
        }
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var vm = services.GetRequiredService<MainWindowViewModel>();
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}