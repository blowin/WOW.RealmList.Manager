using WOW.RealmList.Manager.Avalonia.ViewModels;

namespace WOW.RealmList.Manager.Avalonia;

public interface INavigableViewModel
{
    ViewModelBase? ParentViewModel { get; }
}