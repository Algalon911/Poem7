using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Poem7.ViewModels;
using Poem7.Views;

namespace Poem7;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<TodayPage, TodayPageModel>();
		//builder.Services.AddSingleton<TodayDetailPage, TodayDetailPageViewModel>();
        builder.Services.AddTransient<TodayDetailPage, TodayDetailPageViewModel>();
		//这里单例模式和多例模式会有不同，可以都试试。

        builder.Services.AddSingleton<AboutPage, AboutPageViewModel>();
		builder.Services.AddSingleton<ITodayPoemService, TodayPoemService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
