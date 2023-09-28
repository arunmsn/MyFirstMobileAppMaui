using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;

namespace MyFirstMobileApp.ViewViewModels.StackLayoutContents
{
    public class StackLayoutViewModel : BaseViewModel
    {
	    public string PageTitle { get; set; } = TitleLayout.PageTitle;
        public string StackTitle { get; set; } = TitleLayout.StackTitle;
        public string VerticalTitle { get; set; } = TitleLayout.VerticalTitle;
        public string HorizontalTitle { get; set; } = TitleLayout.HorizontalTitle;
        public string AbsoluteTitle { get; set; } = TitleLayout.AbsoluteTitle;

        public StackLayoutViewModel()
	    {
            PageTitle = TitleLayout.PageTitle;
            StackTitle = TitleLayout.StackTitle;
            HorizontalTitle = TitleLayout.HorizontalTitle;
            VerticalTitle = TitleLayout.VerticalTitle;
            AbsoluteTitle = TitleLayout.AbsoluteTitle;
        }
    }
}


