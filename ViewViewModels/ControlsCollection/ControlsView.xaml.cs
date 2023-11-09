namespace MyFirstMobileApp.ViewViewModels.ControlsCollection;

public partial class ControlsView : ContentPage
{
	public ControlsView()
	{
		InitializeComponent();
		BindingContext = new ControlsViewModel();
	}
}