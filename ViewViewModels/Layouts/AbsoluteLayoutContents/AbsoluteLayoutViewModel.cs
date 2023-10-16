using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Layouts.AbsoluteLayoutContents
{
    public class AbsoluteLayoutViewModel : BaseViewModel
    {
        public String AbsoluteTitle { get; set; } = TitleAbsolute.AbsoluteTitle;

        public AbsoluteLayoutViewModel()
        {
            AbsoluteTitle = TitleAbsolute.AbsoluteTitle;
        }
    }
}
