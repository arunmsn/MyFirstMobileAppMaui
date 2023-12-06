using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.EntryControl.EntryResults
{
    public class EntryResultsViewModel : BaseViewModel
    {
        private string _entryText;

        public EntryResultsViewModel(string entryText)
        {
            Title = TitlesEntry.EntryResultTitle;
            _entryText = entryText;
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
    }
}
