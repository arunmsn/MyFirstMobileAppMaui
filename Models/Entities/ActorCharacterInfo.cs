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
                new ActorCharacterInfo("Ahmed Best", ImageSource.FromFile("Images/StarWarsCharacters/Binks.jpg"), "Binks"),
                new ActorCharacterInfo("Peter Mayhew", ImageSource.FromFile("Images/StarWarsCharacters/Chewie.jpg"), "Chewie"),
                new ActorCharacterInfo("Hayden Christensen", ImageSource.FromFile("Images/StarWarsCharacters/Vader.jpg"), "Darth Vader"),
                new ActorCharacterInfo("Matthew Wood", ImageSource.FromFile("Images/StarWarsCharacters/Grie.jpg"), "Grievous"),
                new ActorCharacterInfo("Harrison Ford", ImageSource.FromFile("Images/StarWarsCharacters/Solo.jpg"), "Han Solo"),
                new ActorCharacterInfo("Carrie Fisher", ImageSource.FromFile("Images/StarWarsCharacters/Leia.jpg"), "Leia"),
                new ActorCharacterInfo("Mark Hamill", ImageSource.FromFile("Images/StarWarsCharacters/Luke.jpg"), "Luke"),
                new ActorCharacterInfo("Samuel L. Jackson", ImageSource.FromFile("Images/StarWarsCharacters/Windu.jpg"), "Mace Windu"),
                new ActorCharacterInfo("Ewan McGregor", ImageSource.FromFile("Images/StarWarsCharacters/Obi.jpg"), "Obi Wan Kenobi"),
                new ActorCharacterInfo("Ian McDiarmid", ImageSource.FromFile("Images/StarWarsCharacters/Palpatine.jpg"), "Palpatine"),
                new ActorCharacterInfo("Frank Oz", ImageSource.FromFile("Images/StarWarsCharacters/Yoda.jpg"), "Yoda"),
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
