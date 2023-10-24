using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.AppImages.Embedded
{
    public class EmbeddedImageViewModel : BaseViewModel
    {
        public EmbeddedImageViewModel() 
        {
            Title = TitleImages.EmbeddedImagesTitle;
        }

        public ImageSource GetImageSource
        {
            get
            {
                return ImageSource.FromFile("Images/circle.jpg");
            }
        }
    }
}
