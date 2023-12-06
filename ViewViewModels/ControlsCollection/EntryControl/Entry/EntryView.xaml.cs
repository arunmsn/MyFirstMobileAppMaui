using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.EntryControl.Entry;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.EntryControl;

public partial class EntryView : ContentPage
{
	public EntryView()
	{
		InitializeComponent();
		BindingContext = new EntryViewModel();
	}

	private void OnSubmitClicked(object sender, EventArgs e)
	{
		string entryText = EntryValue.Text;

		if (string.IsNullOrEmpty(entryText)) 
		{
			//Entry is empty, show an alert
			Application.Current.MainPage.DisplayAlert(TitlesEntry.EntryXAMLTitle, "Entry is empty. Please enter text.", "OK");
		}
		else
		{
			//Entry is not empty, notify the user of what they typed
			Application.Current.MainPage.DisplayAlert(TitlesEntry.EntryXAMLTitle, "You entered:" + entryText, "OK");
		}
	}
}