using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.AppImages.Activity;
using MyFirstMobileApp.ViewViewModels.AppImages.Embedded;
using MyFirstMobileApp.ViewViewModels.AppImages.URIImagesXAML;
using MyFirstMobileApp.ViewViewModels.Base;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.AppImages
{
    public class ImagesMenuViewModel : BaseViewModel
    {
        public string URIImagesTitle { get; set; } = TitleImages.URIImagesTitle;
        public string EmbeddedTitle { get; set; } = TitleImages.EmbeddedTitle;
        public string ActivityTitle { get; set; } = TitleImages.ActivityTitle;

        //Button Commands
        public ICommand OnURIImagesClicked { get; set; }
        public ICommand OnEmbeddedImagesClicked { get; set; }
        public ICommand OnActivityIndicatorClicked { get; set; }

        public ImagesMenuViewModel()
        {
            Title = TitleImages.PageTitle;
            URIImagesTitle = TitleImages.URIImagesTitle;
            EmbeddedTitle = TitleImages.EmbeddedTitle;
            ActivityTitle = TitleImages.ActivityTitle;

            //Set Commands
            OnURIImagesClicked = new Command(OnURIImagesClickedAsync);
            OnEmbeddedImagesClicked = new Command(OnEmbeddedImagesClickedAsync);
            OnActivityIndicatorClicked = new Command(OnActivityIndicatorClickedAsync);
        }

        private async void OnURIImagesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new URIImagesView());
        }

        private async void OnEmbeddedImagesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EmbeddedImageView());
        }

        private async void OnActivityIndicatorClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ActivityIndicatorView());
        }
    }
}
