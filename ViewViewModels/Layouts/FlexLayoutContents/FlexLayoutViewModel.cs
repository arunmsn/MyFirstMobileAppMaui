using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Layouts.FlexLayoutContents
{
    public class FlexLayoutViewModel : BaseViewModel
    {
        public String FlexTitle { get; set; } = TitleFlex.FlexTitle;

        public FlexLayoutViewModel()
        {
            FlexTitle = TitleFlex.FlexTitle;
        }
    }
}
