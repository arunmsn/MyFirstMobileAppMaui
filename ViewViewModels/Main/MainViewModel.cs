using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.Layouts.StackLayoutContents;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public string StackLayoutTitle { get; set; } = TitleMain.StackLayoutTitle;

        //Button Commands
        public ICommand OnLayoutsClicked { get; set; }

        public MainViewModel()
        {
            Title = TitleMain.PageTitle;
            StackLayoutTitle = TitleMain.StackLayoutTitle;

            //Set Commands
            OnLayoutsClicked = new Command(OnLayoutsClickedAsync);
        }

        private async void OnLayoutsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StackLayoutView());
        }
    }
}