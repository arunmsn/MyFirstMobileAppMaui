using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Layouts.HorizontalLayoutContents
{
    public class HorizontalLayoutViewModel : BaseViewModel
    {
        public String HorizontalTitle { get; set; } = TitleHorizontal.PageTitle;

        public HorizontalLayoutViewModel() 
        { 
            HorizontalTitle = TitleHorizontal.PageTitle;
        }
    }
}
