using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using WOW.RealmList.Manager.Domain;

namespace WOW.RealmList.Manager.Avalonia.ViewModels;

public class RealmListViewModel : ViewModelBase, INavigableViewModel
{
    private string? _newRealmListName;
    private string? _newRealmListAddress;
    private readonly int _selectedServerId;

    public ObservableCollection<Domain.RealmList> RealmLists { get; } = new ObservableCollection<Domain.RealmList>();

    public string? NewRealmListName
    {
        get => _newRealmListName;
        set => this.RaiseAndSetIfChanged(ref _newRealmListName, value);
    }

    public string? NewRealmListAddress
    {
        get => _newRealmListAddress;
        set => this.RaiseAndSetIfChanged(ref _newRealmListAddress, value);
    }

    public ReactiveCommand<Unit, Unit> AddRealmListCommand { get; }
    public ReactiveCommand<Domain.RealmList, Unit> EditRealmListCommand { get; }
    public ReactiveCommand<Domain.RealmList, Unit> RemoveRealmListCommand { get; }
    public ReactiveCommand<Domain.RealmList, Unit> NavigateToAccountCommand { get; }

    public ViewModelBase ParentViewModel { get; }

    public MainWindowViewModel MainViewModel { get; }

    public RealmListViewModel(MainWindowViewModel mainViewModel, ViewModelBase parentViewModel, int selectedServerId)
    {
        _selectedServerId = selectedServerId;
        MainViewModel = mainViewModel;
        ParentViewModel = parentViewModel;

        AddRealmListCommand = ReactiveCommand.Create(AddRealmList);
        EditRealmListCommand = ReactiveCommand.Create<Domain.RealmList>(EditRealmList);
        RemoveRealmListCommand = ReactiveCommand.Create<Domain.RealmList>(RemoveRealmList);
        NavigateToAccountCommand = ReactiveCommand.Create<Domain.RealmList>(NavigateToAccount);

        LoadRealmLists();
    }

    private void LoadRealmLists()
    {
        // Загрузка тестовых данных
        RealmLists.Add(new Domain.RealmList { Id = 1, Name = "RealmList 1", Address = "127.0.0.1", ServerId = _selectedServerId, Accounts = [] });
        RealmLists.Add(new Domain.RealmList { Id = 2, Name = "RealmList 2", Address = "192.168.1.1", ServerId = _selectedServerId, Accounts = [] });
    }

    private void AddRealmList()
    {
        if (string.IsNullOrWhiteSpace(NewRealmListName) || string.IsNullOrWhiteSpace(NewRealmListAddress)) return;

        var realmList = new Domain.RealmList
        {
            Id = RealmLists.Count + 1,
            Name = NewRealmListName,
            Address = NewRealmListAddress,
            ServerId = _selectedServerId,
            Accounts = []
        };

        RealmLists.Add(realmList);
        NewRealmListName = string.Empty;
        NewRealmListAddress = string.Empty;
    }

    private void EditRealmList(Domain.RealmList realmList)
    {
        // Логика редактирования реалма
    }

    private void RemoveRealmList(Domain.RealmList realmList)
    {
        RealmLists.Remove(realmList);
    }

    private void NavigateToAccount(Domain.RealmList realmList)
    {
        MainViewModel.NavigateToAccount(this, realmList.Id); // Передаем SelectedRealmListId
    }
}