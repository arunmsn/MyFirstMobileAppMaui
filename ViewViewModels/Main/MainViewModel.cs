using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public string TitleStackLayout { get; set; } = TitleMain.StackLayoutTitle;

        public MainViewModel()
        {
            Title = TitleMain.PageTitle;
        }
    }
}