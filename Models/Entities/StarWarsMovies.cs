using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.Models.Entities
{
    public class StarWarsMovies
    {
        public string NameOfMovie { get; set; }

        public StarWarsMovies() 
        { 
            NameOfMovie = string.Empty;
        }

        public StarWarsMovies(string name)
        {
            //Constructor with parameter (Overloaded)
            NameOfMovie = name;
        }

        public static List<StarWarsMovies> GetMovies()
        {
            return new List<StarWarsMovies>
            {
                new StarWarsMovies(" A New Hope "),
                new StarWarsMovies(" The Empire Strikes Back "),
                new StarWarsMovies(" Return of the Jedi "),
                new StarWarsMovies(" The Phantom Menace "),
                new StarWarsMovies(" Attack of the Clones "),
                new StarWarsMovies(" Revenge of the Sith ")
            };
        }
    }
}
