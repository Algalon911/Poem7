using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Poem7.ViewModels;

public partial class TodayPageModel : ObservableObject
{
    private readonly ITodayPoemService todayPoemService;

    [ObservableProperty]
    bool isLoading;
    [ObservableProperty]
    TodayPoem todayPoem;


    public TodayPageModel(ITodayPoemService todayPoemService)
    {
        this.todayPoemService = todayPoemService;
    }

    [RelayCommand]
    public async Task Loaded()
    {
        IsLoading = true;
        TodayPoem = await todayPoemService.GetTodayPoemAsync();
        IsLoading = false;
    }

    [RelayCommand]
    async Task GoToDetail() => 
        await Shell.Current.GoToAsync("TodayDetailPage", true, new Dictionary<string, object>
        {
            {"TodayPoem", TodayPoem }
        });
}
