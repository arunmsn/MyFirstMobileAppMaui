namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.SWMoviesCollection;

public partial class CollectionsMenuView : ContentPage
{
	public CollectionsMenuView()
	{
		InitializeComponent();
		BindingContext = new CollectionsMenuViewModel();
	}
}