using MyFirstMobileApp.Models.DataAccess;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.Models.Titles;
using MyFirstMobileApp.ViewViewModels.Base;

namespace MyFirstMobileApp.ViewViewModels.Movies
{
    public class MoviesMgmtViewModel : BaseViewModel
    {
        //Properties to bind to the UI
        public List<Movies> VacationCollection { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Visited { get; set; }
        public int Id { get; set; }

        //Text for the button based on whether it's an update or save operation
        public string ButtonText { get; set; }

        //Create an instance of the SQLiteImplementation class to handle SQLite database operations,
        //and assign it to the private readonly field _sqliteService for use throughout the class.
        //readonly variable ensures it can only be assigned a value at the time of declaration or in the constructor
        private readonly SQLiteImplementation _sqliteService = new SQLiteImplementation();

        //Constructor to initialize the ViewModel with existing vacation details if provided
        public MoviesMgmtViewModel(Movies movies)
        {
            //Initialize the collection
            MoviesCollection = new List<Movies>();

            if (movies != null)
            {
                Title = TitleMovies.TitleUpdateMovies;

                //If vacation exists, populate ViewModel properties
                VacationCollection.Add(movies);
                Id = movies.Id;
                Name = movies.Name;
                Trilogy = movies.Trilogy;
                Watched = movies.Watched;

                ButtonText = "Update";
            }
            else
            {
                Title = TitleMovies.TitleAddMovies;

                //If no vacation provided, initialize a new one and set button text to "Save"
                VacationCollection = new List<Vacation>();

                ButtonText = "Save";
            }
        }

        //Command for saving or updating vacation details
        public Command<Vacation> PerformSave
        {
            get
            {
                return new Command<Vacation>(async (Vacation vacation) =>
                {
                    try
                    {
                        //Check for required data before save or update
                        if (string.IsNullOrEmpty(Country) || string.IsNullOrEmpty(City))
                        {
                            await Application.Current.MainPage.DisplayAlert("Message", "Country and City are required.", "Ok");
                            return;
                        }

                        if (ButtonText == "Save")
                        {
                            //Creating a new Vacation instance with ViewModel properties
                            vacation = new Vacation
                            {
                                Id = Id,
                                Country = Country,
                                City = City,
                                Visited = Visited
                            };

                            //Save the new vacation
                            string result = await _sqliteService.SaveVacation(vacation);

                            if (result == string.Empty)
                            {
                                //Send a message to notify about the addition of a new vacation
                                MessagingCenter.Send<Vacation>(vacation, "AddVacation");

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
                            //Creating a new Vacation instance with ViewModel properties for an update
                            vacation = new Vacation
                            {
                                Id = Id,
                                Country = Country,
                                City = City,
                                Visited = Visited
                            };

                            //Update the existing vacation details
                            bool result = await _sqliteService.UpdateVacation(vacation);

                            if (result)
                            {
                                //Send a message to notify about the update of the vacation
                                MessagingCenter.Send<Vacation>(vacation, "UpdateVacation");
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
