using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.ControlsCollection.EntryControl
{
    public class EntryViewModel : BaseViewModel
    {
        public string EntryTitle { get; } = TitlesEntry.EntryTitle;

        public EntryViewModel()
        {
            Title = TitlesEntry.EntryTitle;
        }

    }
}
