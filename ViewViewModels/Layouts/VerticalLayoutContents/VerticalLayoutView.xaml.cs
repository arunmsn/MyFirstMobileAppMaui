namespace MyFirstMobileApp.ViewViewModels.Layouts.VerticalLayoutContents;

public partial class VerticalLayoutView : ContentPage
{
	public VerticalLayoutView()
	{
		InitializeComponent();
		BindingContext = new VerticalLayoutViewModel();
	}
}