using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using Avalonia.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using WOW.RealmList.Manager.Domain;

namespace WOW.RealmList.Manager.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentPage = null!;

    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        private set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public MainWindowViewModel()
    {
        // Начальная страница — список серверов
        CurrentPage = new ServerViewModel(this);
    }

    public void NavigateToRealmList(ViewModelBase parentViewModel, int selectedServerId)
    {
        CurrentPage = new RealmListViewModel(this, parentViewModel, selectedServerId);
    }

    public void NavigateToAccount(ViewModelBase parentViewModel, int selectedRealmListId)
    {
        CurrentPage = new AccountViewModel(this, parentViewModel, selectedRealmListId);
    }

    public void GoBack()
    {
        if (CurrentPage is INavigableViewModel navigableViewModel && navigableViewModel.ParentViewModel != null)
        {
            CurrentPage = navigableViewModel.ParentViewModel;
        }
    }
}