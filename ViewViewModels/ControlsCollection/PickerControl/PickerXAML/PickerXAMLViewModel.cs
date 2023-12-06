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

        private string _selectedItem = string.Empty;

        public PickerXAMLViewModel()
        {
            Title = TitlesPicker.PickerXAMLTitle;

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

        private async void OnSubmitClickedAsync(Object obj)
        {
            if (String.IsNullOrEmpty(_selectedItem)) 
            {
                await Application.Current.MainPage.DisplayAlert(TitlesPicker.PickerXAMLTitle, "A selection must be made!", "OK");
                return;
            }

            List<ActorCharacterInfo> chars = ActorCharacterInfo.GetSampleCharacterData();

            var result = chars.FirstOrDefault(x => x.CharacterName.Equals(_selectedItem));

            await Application.Current.MainPage.Navigation.PushAsync(new PickerResultsView(result.CharacterName, result.ActorName));
        }
    }
}
