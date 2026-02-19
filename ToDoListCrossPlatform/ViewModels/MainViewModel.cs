using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoListCrossPlatform.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
}