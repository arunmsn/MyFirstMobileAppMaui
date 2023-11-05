using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionImageContents;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.SWMoviesCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents
{
    public class CollectionsMenuViewModel : BaseViewModel
    {
        
        public string SWMoviesTitle { get; set; } = TitleCollectionsMenu.SWMoviesTitle;
        public string ImagesTitle { get; set; } = TitleCollectionsMenu.ImagesTitle;

        //Button Commands
        public ICommand OnMoviesClicked { get; set; }
        public ICommand OnCollectionImageClicked { get; set; }


        public CollectionsMenuViewModel()
        {
            Title = TitleMain.CollectionsTitle;

            OnMoviesClicked = new Command(OnMoviesClickedAsync);
            OnCollectionImageClicked = new Command(OnCollectionImageClickedAsync);
        }

        private async void OnMoviesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StarWarsMoviesView());
        }

        private async void OnCollectionImageClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CollectionImageView());
        }

    }
}
