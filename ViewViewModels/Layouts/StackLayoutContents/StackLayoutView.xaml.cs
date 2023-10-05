namespace MyFirstMobileApp.ViewViewModels.Layouts.StackLayoutContents;

public partial class StackLayoutView : ContentPage
{
	public StackLayoutView()
	{
		InitializeComponent();
		BindingContext = new StackLayoutViewModel();
	}
}