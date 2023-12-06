namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.EntryControl;

public partial class EntryResultsView : ContentPage
{
	public EntryResultsView(string entryText)
	{
		InitializeComponent();
		BindingContext = new EntryResultsViewModel(entryText);
	}
}