using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.Models.Entities
{
    public class ActorCharacterInfo
    {
        //Properties - Initialized to an Empty String
        public string ActorName { get; set; } = string.Empty;
        public ImageSource ActorImage { get; set; } = null;
        public string CharacterName { get; set; } = string.Empty;

        public ActorCharacterInfo() 
        { 
            //Constructor
        }

        public ActorCharacterInfo(string actorName, ImageSource actorImage, string characterName)
        {
            //Constructor with Parameters
            ActorName = actorName; 
            ActorImage = actorImage;
            CharacterName = characterName;
        }

        ///<summary>
        ///Retrieves a list of sample character data, each representing an actor's name, an image URL, and the character they portray
        ///</summary>
        ///<returns>A list of ActorCharacterInfo objects containing sample data.</returns>
        public static List<ActorCharacterInfo> GetSampleCharacterData()
        {
            var actors = new List<ActorCharacterInfo>
            {
                //Create ActorCharacterInfo obects with sample data
                new ActorCharacterInfo("Ahmed Best", ImageSource.FromFile("Images/binks.jpg"), "Binks"),
                new ActorCharacterInfo("Peter Mayhew", ImageSource.FromFile("Images/chewie.jpg"), "Chewie"),
                new ActorCharacterInfo("Hayden Christensen", ImageSource.FromFile("Images/vader.jpg"), "Darth Vader"),
                new ActorCharacterInfo("Matthew Wood", ImageSource.FromFile("Images/grie.jpg"), "Grievous"),
                new ActorCharacterInfo("Harrison Ford", ImageSource.FromFile("Images/solo.jpg"), "Han Solo"),
                new ActorCharacterInfo("Carrie Fisher", ImageSource.FromFile("Images/leia.jpg"), "Leia"),
                new ActorCharacterInfo("Mark Hamill", ImageSource.FromFile("Images/luke.jpg"), "Luke"),
                new ActorCharacterInfo("Samuel L. Jackson", ImageSource.FromFile("Images/windu.jpg"), "Mace Windu"),
                new ActorCharacterInfo("Ewan McGregor", ImageSource.FromFile("Images/obi.jpg"), "Obi Wan Kenobi"),
                new ActorCharacterInfo("Ian McDiarmid", ImageSource.FromFile("Images/palpatine.jpg"), "Palpatine"),
                new ActorCharacterInfo("Frank Oz", ImageSource.FromFile("Images/yoda.jpg"), "Yoda"),
            };

            return actors;
        }

        ///<summary>
        ///Retrieves a list of character names from the sample character data
        ///</summary>
        ///<returns>A list of character names extracted from the sample data.</returns>
        public static List<string> GetCharacterNames()
        {
            //Get the sample character data
            var sampleData = GetSampleCharacterData();

            //Select and convert character names to a list
            return sampleData.Select(info => info.CharacterName).ToList();
        }
    }
}
