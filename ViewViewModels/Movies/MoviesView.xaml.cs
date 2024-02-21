namespace MyFirstMobileApp.ViewViewModels.Vacations;

public partial class VacationView : ContentPage
{
    public void MoviesView()
    {
        InitializeComponent();
        BindingContext = new MoviesViewModel();
    }
}