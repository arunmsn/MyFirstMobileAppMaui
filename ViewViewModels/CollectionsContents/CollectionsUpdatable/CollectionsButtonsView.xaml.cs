namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionsUpdatable;

public partial class CollectionsButtonsView : ContentPage
{
	public CollectionsButtonsView()
	{
		InitializeComponent();
		BindingContext = new CollectionsButtonsViewModel();
	}
}