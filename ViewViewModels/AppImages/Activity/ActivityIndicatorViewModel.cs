using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.AppImages.Activity
{
    public class ActivityIndicatorViewModel : BaseViewModel
    {
        private ImageSource _getImageSource;
        private bool _isLoading;
        private bool _isImageVisible;

        public ActivityIndicatorViewModel()
        {
            Title = TitleActivityIndicator.ActivityIndicatorTitle;
            IsLoading = true;
            //Initially, set the image as not visible
            IsImageVisible = false;
            LoadImageAsync();
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public bool IsImageVisible
        {
            get => _isImageVisible;
            set
            {
                _isImageVisible = value;
                OnPropertyChanged(nameof(IsImageVisible));
            }
        }

        public ImageSource GetImageSource
        {
            get => _getImageSource;
            set
            {
                _getImageSource = value;    
                OnPropertyChanged(nameof(GetImageSource));
            }
        }

        private async Task LoadImageAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Utilizing the same URL from our URIImageView
                    var response = await client.GetAsync(TitleURIImages.BubbleImageURL);

                    if (response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        GetImageSource = ImageSource.FromStream(() => stream);
                        //Make the image visible
                        IsImageVisible = true;
                    }
                    else
                    {
                        //Handle error or show a placeholder image
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle any exceptions that may occur during the image loading
                Console.WriteLine($"Error Loading Image: {ex}");
            }
            finally
            {
                //Set isLoading to false after the image is loaded or if there's an error
                IsLoading = false;
            }
        }
    }
}
