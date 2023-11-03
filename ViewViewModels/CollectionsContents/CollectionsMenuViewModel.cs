using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
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

        //Button Commands
        public ICommand OnMoviesClicked { get; set; }

        public CollectionsMenuViewModel()
        {
            Title = TitleMain.CollectionsTitle;

            OnMoviesClicked = new Command(OnMoviesClickedAsync);
        }

        private async void OnMoviesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StarWarsMoviesView());
        }

    }
}
