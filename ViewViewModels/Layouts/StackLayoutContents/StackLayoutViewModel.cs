using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.Layouts.InnerStackLayoutContents;
using MyFirstMobileApp.ViewViewModels.Layouts.VerticalLayoutContents;
using MyFirstMobileApp.ViewViewModels.Layouts.HorizontalLayoutContents;
using MyFirstMobileApp.ViewViewModels.Layouts.AbsoluteLayoutContents;
using MyFirstMobileApp.ViewViewModels.Layouts.FlexLayoutContents;
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
        public string FlexTitle {get; set;} = TitleLayout.FlexTitle;

        public ICommand OnLayoutsClicked { get; set; }
        public ICommand OnVerticalLayoutClicked { get; set; }
        public ICommand OnHorizontalLayoutClicked { get; set; }
        public ICommand OnAbsoluteLayoutClicked { get; set; }
        public ICommand OnFlexLayoutClicked { get; set; }

        public StackLayoutViewModel()
        {
            PageTitle = TitleLayout.PageTitle;
            StackTitle = TitleLayout.StackTitle;
            HorizontalTitle = TitleLayout.HorizontalTitle;
            VerticalTitle = TitleLayout.VerticalTitle;
            AbsoluteTitle = TitleLayout.AbsoluteTitle;
            FlexTitle = TitleLayout.FlexTitle;

            OnLayoutsClicked = new Command(OnLayoutsClickedAsync);
            OnVerticalLayoutClicked = new Command(OnVerticalLayoutClickedAsync);
            OnHorizontalLayoutClicked = new Command(OnHorizontalLayoutClickedAsync);
            OnAbsoluteLayoutClicked = new Command(OnAbsoluteLayoutClickedAsync);
            OnFlexLayoutClicked = new Command(OnFlexLayoutClickedAsync);
        }

        private async void OnLayoutsClickedAsync() 
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InnerStackLayoutView());
        }

        private async void OnVerticalLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VerticalLayoutView());
        }

        private async void OnHorizontalLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HorizontalLayoutView());
        }

        private async void OnAbsoluteLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AbsoluteLayoutView());
        }

        private async void OnFlexLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FlexLayoutView());
        }
    }
}


