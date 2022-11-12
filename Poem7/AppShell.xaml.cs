using Poem7.Views;

namespace Poem7;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(TodayDetailPage), typeof(TodayDetailPage));
    }
}
