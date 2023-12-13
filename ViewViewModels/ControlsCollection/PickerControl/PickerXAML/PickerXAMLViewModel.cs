using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.ControlsCollection.PickerControl.PickerResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.PickerControl.PickerXAML
{
    public class PickerXAMLViewModel : BaseViewModel
    {
        public ImageSource SubmitButton { get; set; } = "Images/submit.png";
        public ICommand OnSubmitClicked { get; }

        private string _selectedCharacter = string.Empty;

        public PickerXAMLViewModel()
        {
            Title = TitlesPicker.PickerXAMLTitle;

            OnSubmitClicked = new Command(OnSubmitClickedAsync);
        }

        public string SelectedCharacter
        {
            get
            {
                return _selectedCharacter;
            }

            set
            {
                if (_selectedCharacter != value) 
                {
                    SetProperty(ref _selectedCharacter, value);
                }

            }
        }

        private async void OnSubmitClickedAsync(Object obj)
        {

            List<ActorCharacterInfo> chars = ActorCharacterInfo.GetSampleCharacterData();

            var result = chars.FirstOrDefault(x => x.CharacterName.Equals(_selectedCharacter));

            await Application.Current.MainPage.Navigation.PushAsync(new PickerResultsView(result.ActorName, result.ActorImage));

            if (String.IsNullOrEmpty(_selectedCharacter))
            {
                await Application.Current.MainPage.DisplayAlert(TitlesPicker.PickerXAMLTitle, "A selection must be made!", "OK");
                return;
            }
        }
    }
}
