namespace MyFirstMobileApp.ViewViewModels.AppImages.Activity;

public partial class ActivityIndicatorView : ContentPage
{
	public ActivityIndicatorView()
	{
        InitializeComponent();
		BindingContext = new ActivityIndicatorViewModel();
	}
}