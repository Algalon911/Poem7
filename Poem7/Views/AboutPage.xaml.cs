using Poem7.ViewModels;

namespace Poem7.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage(AboutPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}