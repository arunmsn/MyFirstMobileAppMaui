using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.PickerControl.PickerResults;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.PickerControl.Picker
{
    public class PickerViewModel : BaseViewModel
    {
        public ImageSource SubmitButton { get; set; } = "Images/submit.png";
        public ICommand OnSubmitClicked { get; }

        private string _selectedItem = string.Empty;

        public PickerViewModel()
        {
            //Set Title
            Title = TitlesPicker.PickerXAMLTitle;

            //Set Submit Button Command
            OnSubmitClicked = new Command(OnSubmitClickedAsync);
        }

        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    SetProperty(ref _selectedItem, value);
                }
            }
        }

        private async void OnSubmitClickedAsync(object obj)
        {
            //Verify user made a selection
            if (string.IsNullOrEmpty(SelectedItem))
            {
                await Application.Current.MainPage.DisplayAlert(TitlesPicker.PickerXAMLTitle, "A selection must be made!", "OK");
                return;
            }

            List<ActorCharacterInfo> chars = new List<ActorCharacterInfo>();

            //Get selection
            var result = chars.FirstOrDefault(x => x.CharacterName.Equals(_selectedItem));

            await Application.Current.MainPage.Navigation.PushAsync(new PickerResultsView(result.CharacterName, result.ActorImage));
        }
    }
}
