using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.StackLayoutContents;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public string TitleStackLayout { get; set; } = TitleMain.StackLayoutTitle;

        //Button Commands
        public ICommand OnLayoutsClicked { get; set; }

        public MainViewModel()
        {
            Title = TitleMain.PageTitle;

            //Set Commands
            OnLayoutsClicked = new Command(OnLayoutsClickedAsync);
        }

        private async void OnLayoutsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StackLayoutView());
        }
    }
}