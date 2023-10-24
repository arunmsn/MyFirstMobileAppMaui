namespace MyFirstMobileApp.ViewViewModels.AppImages.URIImagesXAML;

public partial class URIImagesView : ContentPage
{
	public URIImagesView()
	{
		InitializeComponent();
		BindingContext = new URIImagesViewModel();
	}
}