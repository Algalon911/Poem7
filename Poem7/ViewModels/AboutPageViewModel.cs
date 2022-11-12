using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Poem7.ViewModels;

[ObservableObject]
public partial class AboutPageViewModel
{
    [RelayCommand]
    async Task GoTodayPoem() => await Shell.Current.GoToAsync("//TodayPage");

    [RelayCommand]
    async Task GoToDetail() => await Shell.Current.GoToAsync("TodayDetailPage");

    [RelayCommand]
    async Task GoToDetailWithLocal()
    {
        TodayPoem poem = new TodayPoem()
        {
            Name = "本地歪诗一首",
            Author = "自己",
            Content = "跨于河洛间，\r\n平湖流楚天。\r\n台上冰华澈，\r\n课成应第一。\r\n程回数郡山，\r\n好学异希颜。",
            Source = TodayPoemSources.Local
        };
        await Shell.Current.GoToAsync("TodayDetailPage", true, new Dictionary<string, object>
        {
            {"TodayPoem", poem }
        });
    }
}
