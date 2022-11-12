using Poem7.ViewModels;

namespace Poem7.Views;

public partial class TodayPage : ContentPage
{
	public TodayPage(TodayPageModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}