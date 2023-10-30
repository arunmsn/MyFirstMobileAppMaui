using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.SWMoviesCollection
{
    public class StarWarsMovieViewModel : BaseViewModel
    {
        //ViewModel: Private fields
        private List<StarWarsMovies> _swmovies;

        //ViewModel: Observable collection bound to the View
        //We use ObservableCollection to automatically update the View when the collection changes
        public ObservableCollection<StarWarsMovies> SWMoviesCollection { get; }

        public StarWarsMovieViewModel()
        {
            //ViewModel: Setting the page title for the View
            Title = TitleStarWarsMovies.SWTitle;

            //ViewModel: Initialize the ObservableCollection
            SWMoviesCollection = new ObservableCollection<StarWarsMovies>();

            _swmovies = StarWarsMovies.GetMovies();
            this.LoadMovies();
        }

        //to add: Title, LoadMovies()
    }
}
