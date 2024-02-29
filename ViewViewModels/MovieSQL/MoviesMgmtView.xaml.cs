using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.MovieSQL;


namespace MyFirstMobileApp.ViewViewModels.MovieSQL;

public partial class MoviesMgmtView : ContentPage
{
    public MoviesMgmtView(Movies movies)
    {
        InitializeComponent();
        BindingContext = new MoviesMgmtViewModel(movies);
    }
}