using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionImageContents;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionsUpdatable;
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
        
        public string MoviesTitle { get; set; } = TitleCollectionsMenu.MoviesTitle;
        public string ImagesTitle { get; set; } = TitleCollectionsMenu.ImagesTitle;
        public string ButtonsTitle { get; set; } = TitleCollectionsMenu.ButtonsTitle;

        //Button Commands
        public ICommand OnMoviesClicked { get; set; }
        public ICommand OnCollectionImageClicked { get; set; }
        public ICommand OnButtonsClicked { get; set; }


        public CollectionsMenuViewModel()
        {
            Title = TitleMain.CollectionsTitle;

            OnMoviesClicked = new Command(OnMoviesClickedAsync);
            OnCollectionImageClicked = new Command(OnCollectionImageClickedAsync);
            OnButtonsClicked = new Command(OnButtonsClickedAsync);

        }

        private async void OnMoviesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StarWarsMoviesView());
        }

        private async void OnCollectionImageClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CollectionImageView());
        }

        private async void OnButtonsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CollectionsButtonsView());
        }

    }
}
