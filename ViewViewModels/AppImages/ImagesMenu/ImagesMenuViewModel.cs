using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.AppImages.Embedded;
using MyFirstMobileApp.ViewViewModels.AppImages.URIImagesXAML;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.AppImages
{
    public class ImagesMenuViewModel : BaseViewModel
    {
        public string URIImagesTitle { get; set; } = TitleURIImages.URIImagesTitle;
        public string EmbeddedImagesTitle { get; set; } = TitleEmbedded.EmbeddedImagesTitle;

        //Button Commands
        public ICommand OnURIImagesClicked { get; set; }
        public ICommand OnEmbeddedImagesClicked { get; set; }

        public ImagesMenuViewModel()
        {
            Title = TitleMain.ImagesTitle;
            URIImagesTitle = TitleURIImages.URIImagesTitle;
            EmbeddedImagesTitle = TitleEmbedded.EmbeddedImagesTitle;

            //Set Commands
            OnURIImagesClicked = new Command(OnURIImagesClickedAsync);
            OnEmbeddedImagesClicked = new Command(OnEmbeddedImagesClickedAsync);
        }

        private async void OnURIImagesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new URIImagesView());
        }

        private async void OnEmbeddedImagesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EmbeddedImageView());
        }
    }
}
