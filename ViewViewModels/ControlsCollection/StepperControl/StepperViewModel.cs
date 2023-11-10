using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.StepperControl
{
    public class StepperViewModel : BaseViewModel
    {
        public StepperViewModel()
        {
            Title = TitleStepper.StepperTitle;
        }
    }
}
