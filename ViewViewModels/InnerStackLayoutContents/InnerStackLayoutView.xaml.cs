namespace MyFirstMobileApp.ViewViewModels.InnerStackLayoutContents;

public partial class InnerStackLayoutView : ContentPage
{
	public InnerStackLayoutView()
	{
		InitializeComponent();
		BindingContext = new InnerStackLayoutViewModel();
	}
}