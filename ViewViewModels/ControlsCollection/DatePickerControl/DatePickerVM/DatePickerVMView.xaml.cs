namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.DatePickerControl.DatePickerVM;

public partial class DatePickerVMView : ContentPage
{
	public DatePickerVMView()
	{
		InitializeComponent();
		BindingContext = new DatePickerVMViewModel();
	}
}