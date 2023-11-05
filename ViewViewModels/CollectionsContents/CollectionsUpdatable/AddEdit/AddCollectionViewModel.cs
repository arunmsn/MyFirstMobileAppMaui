using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using System.Windows.Input;

#pragma warning disable CA1416 // Validate platform compatibility
namespace MyFirstMobileApp.ViewViewModels.CollectionsUpdatable.AddEdit
{
    public class AddCollectionViewModel : BaseViewModel
    {
        public ICommand SaveBtnClicked { get; set; }
        private string _movieName = string.Empty;

        public AddCollectionViewModel()
        {
            Title = TitleCollectionsButtons.AddTitle;
            SaveBtnClicked = new Command(PerformSave);
        }

        public string MovieName
        {
            get { return _movieName; }

            set
            {
                if (_movieName != value)
                    SetProperty(ref _movieName, value);
            }
        }

        private void PerformSave()
        {
            if (string.IsNullOrEmpty(_movieName.Trim()))
            {
                // Use Page.DisplayAlert to display the alert
                Application.Current.MainPage.DisplayAlert(TitleCollectionsButtons.AddTitle, "Title cannot be empty", "Ok"); //Changed from Msgs.NotEmpty
                return;
            }

            StarWarsMovies movies = new StarWarsMovies();
            movies.NameOfMovie = _movieName;

            MessagingCenter.Send<StarWarsMovies>(movies, "AddMovies");

            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PopAsync();
            }
        }
    }
}
#pragma warning restore CA1416 // Validate platform compatibility
