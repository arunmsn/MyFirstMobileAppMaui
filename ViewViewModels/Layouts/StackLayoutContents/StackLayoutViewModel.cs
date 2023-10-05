using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.Layouts.InnerStackLayoutContents;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Layouts.StackLayoutContents
{
    public class StackLayoutViewModel : BaseViewModel
    {
        public string PageTitle { get; set; } = TitleLayout.PageTitle;
        public string StackTitle { get; set; } = TitleLayout.StackTitle;
        public string VerticalTitle { get; set; } = TitleLayout.VerticalTitle;
        public string HorizontalTitle { get; set; } = TitleLayout.HorizontalTitle;
        public string AbsoluteTitle { get; set; } = TitleLayout.AbsoluteTitle;

        public ICommand OnLayoutsClicked { get; set; }

        public StackLayoutViewModel()
        {
            PageTitle = TitleLayout.PageTitle;
            StackTitle = TitleLayout.StackTitle;
            HorizontalTitle = TitleLayout.HorizontalTitle;
            VerticalTitle = TitleLayout.VerticalTitle;
            AbsoluteTitle = TitleLayout.AbsoluteTitle;

            OnLayoutsClicked = new Command(OnLayoutsClickedAsync);
        }

        private async void OnLayoutsClickedAsync() 
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InnerStackLayoutView());
        }
    }
}


