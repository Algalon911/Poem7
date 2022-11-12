using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Poem7.ViewModels;

[QueryProperty(nameof(TodayPoem), "TodayPoem")]
[ObservableObject]
public partial class TodayDetailPageViewModel
{
    [ObservableProperty]
    TodayPoem todayPoem;

    [RelayCommand]
    async Task GoBack() => await Shell.Current.GoToAsync("..");
}
