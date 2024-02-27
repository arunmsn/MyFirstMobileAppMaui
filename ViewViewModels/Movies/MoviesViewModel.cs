using MyFirstMobileApp.Models.DataAccess;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.Models.Titles;
using MyFirstMobileApp.ViewViewModels.Base;
using System.Collections.ObjectModel;

namespace MyFirstMobileApp.ViewViewModels.Vacations
{
    //ViewModel for managing Vacation data
    public class MoviesViewModel : BaseViewModel
    {
        private readonly SQLiteImplementation _sqliteService = new SQLiteImplementation();

        //Collection to hold vacation data for the UI
        private ObservableCollection<Movies> _moviesCollection;

        //Property to expose the vacation collection to the UI
        public ObservableCollection<Movies> MoviesCollection
        {
            get { return _moviesCollection; }
            set
            {
                _moviesCollection = value;
                OnPropertyChanged();
                //Debug.WriteLine($"VacationCollection Count: {_vacationCollection?.Count}");
            }
        }

        //Constructor to initialize the ViewModel
        public MoviesViewModel()
        {
            Title = TitleMovies.TitleMovie;

            //Initialize the vacation collection
            MoviesCollection = new ObservableCollection<Movies>();

            //Trigger an asynchronous refresh of the vacation list data
            Task.Run(async () => await RefreshMoviesListData());

            _ = RefreshMoviesListData();
        }

        public async Task RefreshMoviesListData()
        {
            // Retrieve vacation data from the SQLite database
            var vacation = await _sqliteService.GetMovie();

            // Update the ViewModel's vacation collection with the new data
            MoviesCollection = new ObservableCollection<Movies>(vacation);
        }

        //Command to navigate to the VacationMgmtView and handle Adds
        public Command AddCommand
        {
            get
            {
                return new Command<Movies>((Movies movies) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<Vacation>(this, "AddVacation");

                    //Navigate to the VacationAddView, passing a vacation if available
                    Application.Current.MainPage.Navigation.PushAsync(new VacationMgmtView(vacation));

                    //Subscribe to a MessagingCenter event for refreshing data when a new vacation is added
                    MessagingCenter.Subscribe<Vacation>(this, "AddVacation", async (data) =>
                    {
                        //Refresh the vacation list data asynchronously
                        await RefreshVacationListData();
                        //Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Vacation>(this, "AddVacation");
                    });
                });
            }
        }

        //Command to navigate to the VacationMgmtView and handle Updates
        public Command UpdateCommand
        {
            get
            {
                return new Command<Vacation>((Vacation vacation) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<Vacation>(this, "UpdateVacation");

                    //Navigate to the VacationAddView, passing a vacation if available
                    Application.Current.MainPage.Navigation.PushAsync(new VacationMgmtView(vacation));

                    //Subscribe to a MessagingCenter event for refreshing data when a new vacation is updated
                    MessagingCenter.Subscribe<Vacation>(this, "UpdateVacation", async (data) =>
                    {
                        // Refresh the vacation list data asynchronously
                        await RefreshVacationListData();
                        // Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Vacation>(this, "UpdateVacation");
                    });
                });
            }
        }

        //Command to delete a vacation and update the collection
        public Command<Vacation> DeleteCommand
        {
            get
            {
                return new Command<Vacation>((Vacation vacation) =>
                {
                    //Delete the vacation from the SQLite database
                    _ = _sqliteService.DeleteVacation(vacation.Id);

                    //Remove the vacation from the ViewModel's collection
                    VacationCollection.Remove(vacation);
                });
            }
        }
    }
}


/*
                     //Subscribe to a MessagingCenter event for refreshing data when a new vacation is added
                    //MessagingCenter.Subscribe<VacationAddViewModel, Vacation>(this, "AddVacation", async (sender, addedVacation) =>
                    MessagingCenter.Subscribe<Vacation>(this, "AddVacation", async (data) =>
                    {
                        //Refresh the vacation list data asynchronously
                        await RefreshVacationListData();

                        //Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Vacation>(this, "AddVacation");
                        //MessagingCenter.Unsubscribe<VacationAddViewModel, Vacation>(this, "AddVacation");
                    });
*/