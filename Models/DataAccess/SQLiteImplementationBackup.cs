using MyFirstMobileApp.Models.Entities;
using SQLite;

namespace MyFirstMobileApp.Models.DataAccess
{
    public class SQLiteImplementationBackup // : ISQLite
    {
        SQLiteAsyncConnection con;

        public SQLiteImplementationBackup()
        {
            InitializeDatabase();
        }

        // Method to get a connection to SQLite database with table creation
        private async Task InitializeDatabase()
        {
            if (con == null)
            {
                // Set the database file name
                string fileName = DbaseNames.Movies;

                // Get the path to the personal folder on the device
                string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                // Combine the document path and file name to get the complete path
                string path = Path.Combine(documentPath, fileName);

                // Initialize SQLite connection
                con = new SQLiteAsyncConnection(path);

                // Create 'Vacation' table if it does not exist
                con.CreateTableAsync<Movies>();
            }
        }

        // Method to retrieve all vacations from the 'Vacation' table
        public async Task<List<Movies>> GetMovies()
        {
            // Use the returned connection from InitializeDatabase
            //SQLiteAsyncConnection connection = GetConnectionWithCreateDatabase();
            await InitializeDatabase();

            // SQL query to select all rows from 'Vacation' table
            string sql = "SELECT * FROM Movies";

            // Execute the query and retrieve a list of vacations
            //List<Vacation> vacations = con.QueryAsync<Vacation>(sql);
            //List<Vacation> vacations = await con.Table<Vacation>().ToListAsync();
            List<Movies> movies = await con.QueryAsync<Movies>(sql);

            //return await Database.Table<TodoItem>().Where(t => t.Done).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");

            return movies;
        }

        // Method to save a new vacation record
        // Method to save a new vacation record
        public async Task<bool> SaveMovies(Movies movies)
        {
            bool res = false;

            try
            {
                await InitializeDatabase();

                // Check if a record with the same Country and City already exists
                var existingMovie = await con.Table<Movies>()
                    .Where(v => v.Name == movies.Name && v.Trilogy == movies.Trilogy)
                    .FirstOrDefaultAsync();

                if (existingMovie == null)
                {
                    // Insert the vacation record into the 'Vacation' table
                    await con.InsertAsync(movies);
                    res = true;
                }
                else
                {
                    // Record with the same Country and City already exists
                    // You can handle this situation as per your requirements
                    string msg = movies.Name + " and " + movies.Trilogy + " already exists.";
                    await Application.Current.MainPage.DisplayAlert("Message", msg, "Ok");
                    res = false;
                }
            }
            catch (Exception ex)
            {
                res = false;
            }

            return res;
        }

        // Method to update an existing vacation record
        public async Task<bool> UpdateMovies(Movies movies)
        {
            bool res = false;

            try
            {
                // Use the returned connection from InitializeDatabase
                //SQLiteConnection connection = GetConnectionWithCreateDatabase();

                await InitializeDatabase();

                // SQL query to update vacation details based on the provided Id
                string sql = $"UPDATE Movies " +
                             $"SET Name = '{movies.Name}', " +
                             $"Trilogy = '{movies.Trilogy}', " +
                             $"Watched = '{movies.Watched}' " +
                             $"WHERE Id = {movies.Id}";

                // Execute the update query
                //await con.UpdateAsync(sql);
                await con.QueryAsync<Movies>(sql);
                res = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

            return res;
        }

        // Method to delete a vacation record based on the provided Id
        public async Task<bool> DeleteMovies(int Id)
        {
            bool res = false;

            try
            {
                // Use the returned connection from InitializeDatabase
                //SQLiteConnection connection = GetConnectionWithCreateDatabase();
                await InitializeDatabase();

                // SQL query to delete a vacation record from the 'Vacation' table
                string sql = $"DELETE FROM Movies WHERE Id = {Id}";

                // Execute the delete query
                await con.DeleteAsync(sql);

                res = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                res = false;
            }

            return res;
        }

        // Helper method to get the SQLite connection
        /*
        private SQLiteConnection GetConnectionWithCreateDatabase()
        {
            InitializeDatabase();
            return con;
        }
        */
    }
}
