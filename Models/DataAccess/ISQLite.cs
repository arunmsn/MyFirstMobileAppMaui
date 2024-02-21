using Android.Graphics;
using MyFirstMobileApp.Models.Entities;
using SQLite;

namespace MyFirstMobileApp.Models.DataAccess
{
    public interface ISQLite2
    {       
        //SQLiteConnection InitializeDatabase();

        List<Movies> GetMovies();

        bool SaveMovies(Movies movies);

        bool UpdateMovies(Movies movies);

        void DeleteMovies(int Id);
    }
}
