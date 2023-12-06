using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.EntryControl.Entry
{
    public class EntryViewModel : BaseViewModel
    {
        public ICommand OnEntryClicked { get; }

        private string _entryText = string.Empty;
        public EntryViewModel()
        {
            Title = TitlesEntry.EntryTitle;
            OnEntryClicked = new Command(OnEntryClickedAsync);
        }

        public string EntryText
        {
            get
            {
                return _entryText;
            }
            set
            {
                if (_entryText != value)
                {
                    SetProperty(ref _entryText, value);
                }
            }
        }

        private async void OnEntryClickedAsync(object obj)
        {
            if (string.IsNullOrEmpty(_entryText.Trim()))
            {
                await Application.Current.MainPage.DisplayAlert(TitlesEntry.EntryVMTitle, "Entry can't be empty!", "OK");
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new EntryResultsView(_entryText));
        }

    }
}
