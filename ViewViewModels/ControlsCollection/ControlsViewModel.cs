using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.SliderControl;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.StepperControl;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.SwitchControl;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection
{
    public class ControlsViewModel : BaseViewModel
    {
        public string SliderTitle { get; set; } = string.Empty;
        public string StepperTitle { get; set; } = string.Empty;
        public string SwitchTitle { get; set; } = string.Empty;
        public string EntryTitle { get; set; } = string.Empty;
        public string PickerTitle { get; set; } = string.Empty;
        public string DateTimeTitle { get; set; } = string.Empty;

        public ICommand OnSliderClicked { get; set; }
        public ICommand OnStepperClicked { get; set; }
        public ICommand OnSwitchClicked { get; set; }


        public ControlsViewModel()
        {
            Title = TitleControls.PageTitle;

            SliderTitle = TitleControls.SliderTitle;
            StepperTitle = TitleControls.StepperTitle;
            SwitchTitle = TitleControls.SwitchTitle;
            EntryTitle = TitleControls.EntryTitle;
            PickerTitle = TitleControls.PickerTitle;
            DateTimeTitle = TitleControls.DateTimeTitle;

            OnSliderClicked = new Command(OnSliderClickedAsync);
            OnStepperClicked = new Command(OnStepperClickedAsync);
            OnSwitchClicked = new Command(OnSwitchClickedAsync);
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
    }
}
