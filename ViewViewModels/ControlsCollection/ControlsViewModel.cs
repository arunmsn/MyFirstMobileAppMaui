using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.EntryControl;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.SliderControl;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.StepperControl;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.SwitchControl;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection
{
    public class ControlsViewModel : BaseViewModel
    {
        public string SliderTitle { get; set; } = TitleControls.SliderTitle;
        public string StepperTitle { get; set; } = TitleControls.StepperTitle;
        public string SwitchTitle { get; set; } = TitleControls.SwitchTitle;
        public string EntryTitle { get; set; } = TitleControls.EntryTitle;
        public string PickerTitle { get; set; } = TitleControls.PickerTitle;
        public string DateTimeTitle { get; set; } = TitleControls.DateTimeTitle;

        public ICommand OnSliderClicked { get; set; }
        public ICommand OnStepperClicked { get; set; }
        public ICommand OnSwitchClicked { get; set; }
        public ICommand OnEntryClicked { get; set; }



        public ControlsViewModel()
        {
            Title = TitleControls.PageTitle;

            OnSliderClicked = new Command(OnSliderClickedAsync);
            OnStepperClicked = new Command(OnStepperClickedAsync);
            OnSwitchClicked = new Command(OnSwitchClickedAsync);
            OnEntryClicked = new Command(OnEntryClickedAsync);
        }

        private async void OnSliderClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SliderView());
        }
        private async void OnStepperClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StepperView());
        }
        private async void OnSwitchClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SwitchView());
        }

        private async void OnEntryClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EntryView());
        }
    }
}
