namespace MyFirstMobileApp.ViewViewModels.Layouts.InnerStackLayoutContents;

public partial class InnerStackLayoutView : ContentPage
{
	public InnerStackLayoutView()
	{
		InitializeComponent();
		BindingContext = new InnerStackLayoutViewModel();
	}
}