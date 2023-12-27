using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.DatePickerControl.DatePickerXAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.DatePickerControl
{
    public class DatePickerViewModel : BaseViewModel
    {
        public ICommand OnDatePickerXAMLClicked { get; set; }
        public ICommand OnDatePickerVMClicked { get; set; }


        public DatePickerViewModel()
        {
            Title = TitleDatePicker.DatePickerTitle;

            OnDatePickerXAMLClicked = new Command(OnXAMLClickedAsync);
            OnDatePickerVMClicked = new Command(OnVMClickedAsync);

        }

        private async void OnXAMLClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DatePickerXAMLView());
        }
        private async void OnVMClickedAsync()
        {
            //await Application.Current.MainPage.Navigation.PushAsync(new DatePickerVMView());
        }
    }
}
