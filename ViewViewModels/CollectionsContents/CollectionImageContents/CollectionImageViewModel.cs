using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionImageContents
{
    public class CollectionImageViewModel : BaseViewModel
    {
        public ObservableCollection<ActorCharacterInfo> SWCollection { get; }
        private List<ActorCharacterInfo> _starwars;

        public CollectionImageViewModel()
        {
            Title = TitleCollectionImages.CharactersImagesTitle;

            //Instantiate Observable SWCollection
            SWCollection = new ObservableCollection<ActorCharacterInfo>();
            _starwars = ActorCharacterInfo.GetSampleCharacterData();
            this.loadStarWars();
        }
        
        private void loadStarWars()
        {
            try
            {
                SWCollection.Clear();
                foreach (var s in _starwars)
                {
                    SWCollection.Add(s);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
