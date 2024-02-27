using MyFirstMobileApp.Models.DataAccess;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.Models.Titles;
using MyFirstMobileApp.ViewViewModels.Base;
using System.Collections.ObjectModel;

namespace MyFirstMobileApp.ViewViewModels.Moviess
{
    //ViewModel for managing Movies data
    public class MoviesViewModel : BaseViewModel
    {
        private readonly SQLiteImplementation _sqliteService = new SQLiteImplementation();

        //Collection to hold Movies data for the UI
        private ObservableCollection<Movies> _moviesCollection;

        //Property to expose the Movies collection to the UI
        public ObservableCollection<Movies> MoviesCollection
        {
            get { return _moviesCollection; }
            set
            {
                _moviesCollection = value;
                OnPropertyChanged();
                //Debug.WriteLine($"MoviesCollection Count: {_MoviesCollection?.Count}");
            }
        }

        //Constructor to initialize the ViewModel
        public MoviesViewModel()
        {
            Title = TitleMovies.TitleMovie;

            //Initialize the Movies collection
            MoviesCollection = new ObservableCollection<Movies>();

            //Trigger an asynchronous refresh of the Movies list data
            Task.Run(async () => await RefreshMoviesListData());

            _ = RefreshMoviesListData();
        }

        public async Task RefreshMoviesListData()
        {
            // Retrieve Movies data from the SQLite database
            var Movies = await _sqliteService.GetMovie();

            // Update the ViewModel's Movies collection with the new data
            MoviesCollection = new ObservableCollection<Movies>(Movies);
        }

        //Command to navigate to the MoviesMgmtView and handle Adds
        public Command AddCommand
        {
            get
            {
                return new Command<Movies>((Movies movies) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<Movies>(this, "AddMovies");

                    //Navigate to the MoviesAddView, passing a Movies if available
                    Application.Current.MainPage.Navigation.PushAsync(new MoviesMgmtView(Movies));

                    //Subscribe to a MessagingCenter event for refreshing data when a new Movies is added
                    MessagingCenter.Subscribe<Movies>(this, "AddMovies", async (data) =>
                    {
                        //Refresh the Movies list data asynchronously
                        await RefreshMoviesListData();
                        //Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Movies>(this, "AddMovies");
                    });
                });
            }
        }

        //Command to navigate to the MoviesMgmtView and handle Updates
        public Command UpdateCommand
        {
            get
            {
                return new Command<Movies>((Movies Movies) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<Movies>(this, "UpdateMovies");

                    //Navigate to the MoviesAddView, passing a Movies if available
                    Application.Current.MainPage.Navigation.PushAsync(new MoviesMgmtView(Movies));

                    //Subscribe to a MessagingCenter event for refreshing data when a new Movies is updated
                    MessagingCenter.Subscribe<Movies>(this, "UpdateMovies", async (data) =>
                    {
                        // Refresh the Movies list data asynchronously
                        await RefreshMoviesListData();
                        // Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Movies>(this, "UpdateMovies");
                    });
                });
            }
        }

        //Command to delete a Movies and update the collection
        public Command<Movies> DeleteCommand
        {
            get
            {
                return new Command<Movies>((Movies Movies) =>
                {
                    //Delete the Movies from the SQLite database
                    _ = _sqliteService.DeleteMovies(Movies.Id);

                    //Remove the Movies from the ViewModel's collection
                    MoviesCollection.Remove(Movies);
                });
            }
        }
    }
}


/*
                     //Subscribe to a MessagingCenter event for refreshing data when a new Movies is added
                    //MessagingCenter.Subscribe<MoviesAddViewModel, Movies>(this, "AddMovies", async (sender, addedMovies) =>
                    MessagingCenter.Subscribe<Movies>(this, "AddMovies", async (data) =>
                    {
                        //Refresh the Movies list data asynchronously
                        await RefreshMoviesListData();

                        //Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Movies>(this, "AddMovies");
                        //MessagingCenter.Unsubscribe<MoviesAddViewModel, Movies>(this, "AddMovies");
                    });
*/