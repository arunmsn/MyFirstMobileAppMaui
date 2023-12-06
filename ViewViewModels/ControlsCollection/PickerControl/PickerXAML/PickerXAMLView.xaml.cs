namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.PickerControl.PickerXAML;

public partial class PickerXAMLView : ContentPage
{
	public PickerXAMLView()
	{
		InitializeComponent();
		BindingContext = new PickerXAMLViewModel();
	}
}