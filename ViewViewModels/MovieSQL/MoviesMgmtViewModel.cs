using MyFirstMobileApp.Models.DataAccess;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.Models.Titles;
using MyFirstMobileApp.ViewViewModels.Base;

namespace MyFirstMobileApp.ViewViewModels.MovieSQL
{
    public class MoviesMgmtViewModel : BaseViewModel
    {
        //Properties to bind to the UI
        public List<Movies> MoviesCollection { get; set; }
        public string Name { get; set; }
        public string Trilogy { get; set; }
        public int Watched { get; set; }
        public int Id { get; set; }

        //Text for the button based on whether it's an update or save operation
        public string ButtonText { get; set; }

        //Create an instance of the SQLiteImplementation class to handle SQLite database operations,
        //and assign it to the private readonly field _sqliteService for use throughout the class.
        //readonly variable ensures it can only be assigned a value at the time of declaration or in the constructor
        private readonly SQLiteImplementation _sqliteService = new SQLiteImplementation();

        //Constructor to initialize the ViewModel with existing Movies details if provided
        public MoviesMgmtViewModel(Models.Entities.Movies movies)
        {
            //Initialize the collection
            MoviesCollection = new List<Movies>();

            if (movies != null)
            {
                Title = TitleMovies.TitleUpdateMovies;

                //If Movies exists, populate ViewModel properties
                MoviesCollection.Add(movies);
                Id = movies.Id;
                Name = movies.Name;
                Trilogy = movies.Trilogy;
                Watched = movies.Watched;

                ButtonText = "Update";
            }
            else
            {
                Title = TitleMovies.TitleAddMovies;

                //If no Movies provided, initialize a new one and set button text to "Save"
                MoviesCollection = new List<Movies>();

                ButtonText = "Save";
            }
        }

        //Command for saving or updating Movies details
        public Command<Movies> PerformSave
        {
            get
            {
                return new Command<Movies>(async (Movies) =>
                {
                    try
                    {
                        //Check for required data before save or update
                        if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Trilogy))
                        {
                            await Application.Current.MainPage.DisplayAlert("Message", "Name and Trilogy are required.", "Ok");
                            return;
                        }

                        if (ButtonText == "Save")
                        {
                            //Creating a new Movies instance with ViewModel properties
                            Movies = new Movies
                            {
                                Id = Id,
                                Name = Name,
                                Trilogy = Trilogy,
                                Watched = Watched
                            };

                            //Save the new Movies
                            string result = await _sqliteService.SaveMovie(Movies);

                            if (result == string.Empty)
                            {
                                //Send a message to notify about the addition of a new Movies
                                MessagingCenter.Send<Movies>(Movies, "AddMovies");

                                if (Application.Current.MainPage != null)
                                {
                                    await Application.Current.MainPage.Navigation.PopAsync();
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Message", result, "Ok");
                            }
                        }
                        else
                        {
                            //Creating a new Movies instance with ViewModel properties for an update
                            Movies = new Movies
                            {
                                Id = Id,
                                Name = Name,
                                Trilogy = Trilogy,
                                Watched = Watched
                            };

                            //Update the existing Movies details
                            bool result = await _sqliteService.UpdateMovies(Movies);

                            if (result)
                            {
                                //Send a message to notify about the update of the Movies
                                MessagingCenter.Send<Movies>(Movies, "UpdateMovies");
                                await Application.Current.MainPage.Navigation.PopAsync();
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Message", "Data Failed To Update", "Ok");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                    }
                });
            }
        }
    }
}
