using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.AppImages.URIImagesXAML
{
    public class URIImagesViewModel : BaseViewModel
    {
        private ImageSource _getImageSource;

        public string BubbleImageURL = TitleURIImages.BubbleImageURL;

        public URIImagesViewModel()
        {
            Title = TitleURIImages.URIImagesTitle;
            BubbleImageURL = TitleURIImages.BubbleImageURL;
        }

        public ImageSource GetImageSource
        {
            get 
            {
                if (_getImageSource == null)
                {
                    _getImageSource = GetImage();
                }

                return _getImageSource;
            }
        }

        private ImageSource GetImage()
        {
            var imgsrc = new UriImageSource { Uri = new Uri(BubbleImageURL) };
            imgsrc.CachingEnabled = false;
            imgsrc.CacheValidity = TimeSpan.FromHours(1);

            return imgsrc;
        }
    }
}
