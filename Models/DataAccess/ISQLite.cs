using MyFirstMobileApp.Models.Entities;

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
