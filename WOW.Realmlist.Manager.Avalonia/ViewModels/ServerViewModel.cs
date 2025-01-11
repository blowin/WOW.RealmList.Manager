using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using DynamicData;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using WOW.RealmList.Manager.Domain;

namespace WOW.RealmList.Manager.Avalonia.ViewModels;

public class ServerViewModel : ViewModelBase
{
    private string? _newServerName;

    public ObservableCollection<Server> Servers { get; } = new ObservableCollection<Server>();

    public string? NewServerName
    {
        get => _newServerName;
        set => this.RaiseAndSetIfChanged(ref _newServerName, value);
    }

    public ReactiveCommand<Unit, Unit> AddServerCommand { get; }
    public ReactiveCommand<Server, Unit> EditServerCommand { get; }
    public ReactiveCommand<Server, Unit> RemoveServerCommand { get; }
    public ReactiveCommand<Server, Unit> NavigateToRealmListCommand { get; }

    public MainWindowViewModel MainViewModel { get; }

    public ServerViewModel(MainWindowViewModel mainViewModel)
    {
        MainViewModel = mainViewModel;

        AddServerCommand = ReactiveCommand.Create(AddServer);
        EditServerCommand = ReactiveCommand.Create<Server>(EditServer);
        RemoveServerCommand = ReactiveCommand.Create<Server>(RemoveServer);
        NavigateToRealmListCommand = ReactiveCommand.Create<Server>(NavigateToRealmList);

        LoadServers();
    }

    private void LoadServers()
    {
        // Загрузка тестовых данных
        Servers.Add(new Server
        {
            Id = 1,
            Name = "Circle",
            Realmlists = new List<Domain.RealmList>
            {
                new Domain.RealmList
                {
                    Name = "3.3.5",
                    Address = "logon.wowcircle.com",
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            Login = "Test"
                        }
                    }
                }
            }
        });
        Servers.Add(new Server { Id = 2, Name = "Server 2", Realmlists = [] });
    }

    private void AddServer()
    {
        if (string.IsNullOrWhiteSpace(NewServerName)) return;

        var server = new Server { Id = Servers.Count + 1, Name = NewServerName, Realmlists = [] };
        Servers.Add(server);
        NewServerName = string.Empty;
    }

    private void EditServer(Server server)
    {
        // Логика редактирования сервера
    }

    private void RemoveServer(Server server)
    {
        Servers.Remove(server);
    }

    private void NavigateToRealmList(Server server)
    {
        MainViewModel.NavigateToRealmList(this, server.Id); // Передаем SelectedServerId
    }
}