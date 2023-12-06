namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.PickerControl.PickerVM;

public partial class PickerVMView : ContentPage
{
	public PickerVMView()
	{
		InitializeComponent();
        BindingContext = new PickerVMViewModel();
    }
}