using CommunityToolkit.Mvvm.ComponentModel;

namespace Project5.ViewModels;
public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
