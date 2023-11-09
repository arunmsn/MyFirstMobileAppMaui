using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.SliderControl
{
    public class SliderViewModel : BaseViewModel
    {
        public string SliderTitle { get; } = TitleSlider.SliderTitle;
        
        public SliderViewModel()
        {
            Title = "Slider Control";
        }
    }
}
