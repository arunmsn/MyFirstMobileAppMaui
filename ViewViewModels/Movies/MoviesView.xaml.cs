namespace MyFirstMobileApp.ViewViewModels.Moviess;

public partial class MoviesView : ContentPage
{
    public void MoviesView()
    {
        InitializeComponent();
        BindingContext = new MoviesViewModel();
    }
}