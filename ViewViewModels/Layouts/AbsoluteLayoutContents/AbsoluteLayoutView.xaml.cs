namespace MyFirstMobileApp.ViewViewModels.Layouts.AbsoluteLayoutContents;

public partial class AbsoluteLayoutView : ContentPage
{
	public AbsoluteLayoutView()
	{
		InitializeComponent();
        BindingContext = new AbsoluteLayoutViewModel();
    }
}