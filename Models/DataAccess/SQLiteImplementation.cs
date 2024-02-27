using MyFirstMobileApp.Models.Entities;
using SQLite;

namespace MyFirstMobileApp.Models.DataAccess
{
    public class SQLiteImplementation
    {
        //SQLiteAsyncConnection: Is a class provided by SQLite-net to facilitate asynchronous database operations.
        //con: This is a variable name chosen to represent the SQLite database connection.
        SQLiteAsyncConnection con;

        public SQLiteImplementation()
        {
            //Initialize and sets up the database. The method is async, as a result
            //we ignore any return value by using the discard symbole "_" which tells
            //the compiler that the result of the method is intentionally being ignored.
            //This can be useful when you have a method that returns a value,
            //but you don't need that value for the current operation.
            _ = InitializeDatabase();
        }

        //Method to get a connection to SQLite database with table creation
        private async Task InitializeDatabase()
        {
            if (con == null)
            {
                //Set the database file name
                string fileName = DbaseNames.Movies;

                //Get the path to the personal folder on the device
                string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                //Combine the document path and file name to get the complete path
                string path = Path.Combine(documentPath, fileName);

                //Check if the directory exists, create it if it doesn't
                if (!File.Exists(path))
                {
                    //Create the directory if it doesn't exist
                    Directory.CreateDirectory(documentPath);
                }

                //Initialize SQLite connection
                con = new SQLiteAsyncConnection(path);

                //Create 'Movies' table if it does not exist
                await con.CreateTableAsync<Movies>();
            }
        }

        //Method to retrieve all Moviess from the 'Movies' table
        public async Task<List<Movies>> GetMovies()
        {
            //Use the returned connection from InitializeDatabase
            await InitializeDatabase();

            //SQL query to select all rows from 'Movies' table
            string sql = "SELECT * FROM Movies";

            //Execute the query and retrieve a list of Moviess
            List<Movies> movies = await con.QueryAsync<Movies>(sql);

            return movies;
        }

        //Method to save a new Movies record
        public async Task<string> SaveMovie(Movies movies)
        {
            string result = string.Empty;

            try
            {
                await InitializeDatabase();

                //Check if a record with the same Name and Trilogy already exists
                var existingMovies = await con.Table<Movies>()
                      .Where(v => v.Name == movies.Name && v.Trilogy == movies.Trilogy)
                      .FirstOrDefaultAsync();

                if (existingMovies == null)
                {
                    //Insert the Movies record into the 'Movies' table
                    await con.InsertAsync(movies);
                }
                else
                {
                    //Record with the same Name and Trilogy already exists
                    string msg = movies.Name + " and " + movies.Trilogy + " already exists.";
                    //await Application.Current.MainPage.DisplayAlert("Message", msg, "Ok");

                    result = msg;
                }
            }
            catch (Exception ex)
            {
                result = "ERROR: " + ex.Message;
            }

            return result;
        }

        //Method to update an existing Movies record
        public async Task<bool> UpdateMovies(Movies movies)
        {
            bool res = false;

            try
            {
                //Use the returned connection from InitializeDatabase
                await InitializeDatabase();

                //$ is short-hand for String.Format, used with string 
                //interpolations (e.g. {0}).  Used in C# 6.0
                //SQL query to update Movies details based on the provided Id
                string sql = $"UPDATE Movies " +
                                  $"SET Name = '{movies.Name}', " +
                                  $"Trilogy = '{movies.Trilogy}', " +
                                  $"Watched = '{movies.Watched}' " +
                                  $"WHERE Id = {movies.Id}";

                //Execute the update query
                await con.QueryAsync<Movies>(sql);
                res = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

            return res;
        }

        //Method to delete a Movies record based on the provided Id
        public async Task<bool> DeleteMovies(int Id)
        {
            bool res = false;

            try
            {
                //Use the returned connection from InitializeDatabase
                await InitializeDatabase();

                /*****************************************************************************
                 * A SQL query is not the correct usage for deleting records based on their primary key. 
                 * For deleting a record by its primary key, DeleteAsync expects the actual object or 
                 * the primary key value, not an SQL query.
                 ******************************************************************************/
                var movieToDelete = await con.Table<Movies>().FirstOrDefaultAsync(v => v.Id == Id);

                if (movieToDelete != null)
                {
                    //Delete the retrieved Movies
                    await con.DeleteAsync(movieToDelete);
                    res = true;
                }
            }
            catch (Exception ex)
            {
                //Handle exceptions
                res = false;
            }

            return res;
        }
    }
}
