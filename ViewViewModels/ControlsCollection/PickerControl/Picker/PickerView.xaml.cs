using MyFirstMobileApp.ViewViewModels.ControlsCollection.PickerControl.Picker;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.PickerControl;

public partial class PickerView : ContentPage
{
	public PickerView()
	{
		InitializeComponent();
		BindingContext = new PickerViewModel();
	}
}