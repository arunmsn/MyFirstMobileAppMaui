using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.SliderControl;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection
{
    public class ControlsViewModel : BaseViewModel
    {
        public string SliderTitle = string.Empty;
        public string StepperTitle = string.Empty;
        public string SwitchTitle = string.Empty;
        public string EntryTitle = string.Empty;
        public string PickerTitle = string.Empty;
        public string DateTimeTitle = string.Empty;

        public ICommand OnSliderClicked { get; set; }

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
        }

        private async void OnSliderClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SliderView());
        }
    }
}
