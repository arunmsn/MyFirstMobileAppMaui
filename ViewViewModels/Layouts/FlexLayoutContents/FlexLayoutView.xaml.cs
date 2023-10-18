namespace MyFirstMobileApp.ViewViewModels.Layouts.FlexLayoutContents;

public partial class FlexLayoutView : ContentPage
{
	public FlexLayoutView()
	{
		InitializeComponent();
		BindingContext = new FlexLayoutViewModel();
	}
}