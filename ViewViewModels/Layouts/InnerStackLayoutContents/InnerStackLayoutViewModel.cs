using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Layouts.InnerStackLayoutContents
{
    public class InnerStackLayoutViewModel : BaseViewModel
    {
        public string InnerTitle { get; set; } = InnerTitleLayout.InnerPageTitle;

        public InnerStackLayoutViewModel()
        {
            InnerTitle = InnerTitleLayout.InnerPageTitle;
        }
    }
}


