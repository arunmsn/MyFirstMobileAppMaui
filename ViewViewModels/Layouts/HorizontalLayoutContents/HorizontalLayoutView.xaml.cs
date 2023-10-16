namespace MyFirstMobileApp.ViewViewModels.Layouts.HorizontalLayoutContents;

public partial class HorizontalLayoutView : ContentPage
{
	public HorizontalLayoutView()
	{
		InitializeComponent();
		BindingContext = new HorizontalLayoutViewModel();
	}
}