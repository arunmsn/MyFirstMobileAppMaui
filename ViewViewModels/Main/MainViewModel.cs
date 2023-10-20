using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.AppImages.URIImagesXAML;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.Layouts.StackLayoutContents;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public string StackLayoutTitle { get; set; } = TitleMain.StackLayoutTitle;
        public string URIImagesTitle { get; set; } = TitleMain.URIImagesTitle;

        //Button Commands
        public ICommand OnLayoutsClicked { get; set; }
        public ICommand OnImagesClicked { get; set; }

        public MainViewModel()
        {
            Title = TitleMain.PageTitle;
            StackLayoutTitle = TitleMain.StackLayoutTitle;
            URIImagesTitle = TitleMain.URIImagesTitle;


            //Set Commands
            OnLayoutsClicked = new Command(OnLayoutsClickedAsync);
            OnImagesClicked = new Command(OnImagesClickedAsync);
        }

        private async void OnLayoutsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StackLayoutView());
        }

        private async void OnImagesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new URIImagesView());
        }
    }
}