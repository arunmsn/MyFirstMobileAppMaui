namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.DatePickerControl;

public partial class DatePickerView : ContentPage
{
	public DatePickerView()
	{
		InitializeComponent();
		BindingContext = new DatePickerViewModel();
	}
}