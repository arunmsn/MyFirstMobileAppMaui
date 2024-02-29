using MyFirstMobileApp.ViewViewModels.MovieSQL;

namespace MyFirstMobileApp.ViewViewModels.Moviess;

public partial class MoviesView : ContentPage
{
    public MoviesView()
    {
        InitializeComponent();
        BindingContext = new MoviesViewModel();
    }
}