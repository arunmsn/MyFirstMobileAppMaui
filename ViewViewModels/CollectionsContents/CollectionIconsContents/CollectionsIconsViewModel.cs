using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.CollectionsUpdatable.AddEdit;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionsUpdatable
{
    public class CollectionsIconsViewModel : BaseViewModel
    {
        public ObservableCollection<StarWarsMovies> SWMoviesCollection { get; set; }

        public CollectionsIconsViewModel()
        {
            //Set the title for this view
            Title = TitleCollectionsIcons.IconsTitle;

            //Create a new ObservableCollection to store movies
            SWMoviesCollection = new ObservableCollection<StarWarsMovies>();

            //Load movies from the data source
            LoadMovies();
        }

        private void LoadMovies()
        {
            IsBusy = true;

            try
            {
                //Clear the existing collection
                SWMoviesCollection.Clear();

                //Get a list of Star Wars movies and add them to the collection
                var starWarsMovies = StarWarsMovies.GetMovies();
                foreach (var movie in starWarsMovies)
                {
                    SWMoviesCollection.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }

        //Command to add a new movie
        public ICommand AddCommand => new Command(async () =>
        {
            //Navigate to the AddCollectionView
            await Application.Current.MainPage.Navigation.PushAsync(new AddCollectionView());

            //****************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you add a movie in AddCollectionView, it sends on "AddMovies" event.
            // CollectionsButtonsViewModel listens for this event and updates the movie list.
            //****************
            //Subscribe to the "AddMovies" messaging event to receive updated data from AddCollectionView
            MessagingCenter.Subscribe<StarWarsMovies>(this, "AddMovies", async data =>
            {
                //Add the new movie data to the collection
                SWMoviesCollection.Add(data);

                //Unsubscribe from the messaging event
                MessagingCenter.Unsubscribe<StarWarsMovies>(this, "AddMovies");
            });
        });

        //Command to update a movie
        public ICommand UpdateCommand => new Command<StarWarsMovies>(async movie =>
        {
            //Get the index of the selected movie in the collection
            var index = SWMoviesCollection.IndexOf(movie);

            //Navigate to the AddCollectionView
            await Application.Current.MainPage.Navigation.PushAsync(new EditCollectionView(movie));

            //****************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you update a movie in EditCollectionView, it sends on "UpdateMovies" event.
            // CollectionsButtonsViewModel listens for this event and updates the movie list.
            //****************
            //Subscribe to the "UpdateMovies" messaging event to receive updated data from EditCollectionView
            MessagingCenter.Subscribe<StarWarsMovies>(this, "UpdateMovies", updatedMovie =>
            {
                //Update the movie in the collection with the edited data
                SWMoviesCollection[index] = updatedMovie;
            });
        });

        //Command to delete a movie
        public ICommand DeleteCommand => new Command<StarWarsMovies>(movie =>
        {
            //Remove the selected movie from the collection
            SWMoviesCollection.Remove(movie);
        });
    }
}
