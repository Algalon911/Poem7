using Poem7.ViewModels;

namespace Poem7.Views;

public partial class TodayDetailPage : ContentPage
{
	public TodayDetailPage(TodayDetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}