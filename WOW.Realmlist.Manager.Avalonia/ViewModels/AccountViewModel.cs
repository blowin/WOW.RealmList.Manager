using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using DynamicData;
using ReactiveUI;
using WOW.RealmList.Manager.Domain;

namespace WOW.RealmList.Manager.Avalonia.ViewModels;

public class AccountViewModel : ViewModelBase, INavigableViewModel
{
    private string? _newAccountLogin;
    private string? _newAccountPassword;
    private readonly int _selectedRealmListId;

    public ObservableCollection<Account> Accounts { get; } = new ObservableCollection<Account>();

    public string? NewAccountLogin
    {
        get => _newAccountLogin;
        set => this.RaiseAndSetIfChanged(ref _newAccountLogin, value);
    }

    public string? NewAccountPassword
    {
        get => _newAccountPassword;
        set => this.RaiseAndSetIfChanged(ref _newAccountPassword, value);
    }

    public ReactiveCommand<Unit, Unit> AddAccountCommand { get; }
    public ReactiveCommand<Account, Unit> EditAccountCommand { get; }
    public ReactiveCommand<Account, Unit> RemoveAccountCommand { get; }

    public ViewModelBase ParentViewModel { get; }

    public MainWindowViewModel MainViewModel { get; }

    public AccountViewModel(MainWindowViewModel mainViewModel, ViewModelBase parentViewModel, int selectedRealmListId)
    {
        _selectedRealmListId = selectedRealmListId;
        MainViewModel = mainViewModel;
        ParentViewModel = parentViewModel;

        AddAccountCommand = ReactiveCommand.Create(AddAccount);
        EditAccountCommand = ReactiveCommand.Create<Account>(EditAccount);
        RemoveAccountCommand = ReactiveCommand.Create<Account>(RemoveAccount);

        LoadAccounts();
    }

    private void LoadAccounts()
    {
        // Загрузка тестовых данных
        Accounts.Add(new Account { Id = 1, Login = "User1", Password = "Pass1", RealmListId = _selectedRealmListId });
        Accounts.Add(new Account { Id = 2, Login = "User2", Password = "Pass2", RealmListId = _selectedRealmListId });
    }

    private void AddAccount()
    {
        if (string.IsNullOrWhiteSpace(NewAccountLogin)) return;

        var account = new Account
        {
            Id = Accounts.Count + 1,
            Login = NewAccountLogin,
            Password = NewAccountPassword,
            RealmListId = _selectedRealmListId
        };

        Accounts.Add(account);
        NewAccountLogin = string.Empty;
        NewAccountPassword = string.Empty;
    }

    private void EditAccount(Account account)
    {
        // Логика редактирования аккаунта
    }

    private void RemoveAccount(Account account)
    {
        Accounts.Remove(account);
    }
}