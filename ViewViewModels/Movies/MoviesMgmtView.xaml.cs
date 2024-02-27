using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Movies;
using MyFirstMobileApp.ViewViewModels.Movies;

public partial class MoviesMgmtView : ContentPage
{
    public MoviesMgmtView(Movies movies)
    {
        InitializeComponent();
        BindingContext = new MoviesMgmtViewModel(movies);
    }
}