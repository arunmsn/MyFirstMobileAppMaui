using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Layouts.VerticalLayoutContents
{
    public class VerticalLayoutViewModel : BaseViewModel
    {
        public String VerticalTitle { get; set; } = TitleVertical.VerticalTitle;

        public VerticalLayoutViewModel()
        {
            VerticalTitle = TitleVertical.VerticalTitle;
        }
    }
}
