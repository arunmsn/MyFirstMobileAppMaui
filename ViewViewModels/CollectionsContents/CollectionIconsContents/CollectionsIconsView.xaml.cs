using MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionsUpdatable;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionIconsContents;

public partial class CollectionsIconsView : ContentPage
{
	public CollectionsIconsView()
	{
		InitializeComponent();
		BindingContext = new CollectionsIconsViewModel();
	}
}