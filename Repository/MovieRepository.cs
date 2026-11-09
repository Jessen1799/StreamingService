using MongoDB.Bson;
using MongoDB.Driver;
using StreamingService.Model;

namespace StreamingService.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieRepository()
        {
            var connectionString = "mongodb://localhost:27017/";
            
            MongoClient testClient = new MongoClient(connectionString);

            var database = testClient.GetDatabase("dbStreaming");
            
            _movies = database.GetCollection<Movie>("Movies");
            
        }
     
        public void AddMovie(Movie movie)
        {
            //MockDataBase.AddMovie(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            //MockDataBase.DeleteMovie(movie.Id);
        }

        List<Movie> movies;
        public List<Movie> GetAllMovies()
        {
            return movies;

        }

        public async Task<Movie> GetMovie(string title)
        {
            return await _movies.Find(m => m.Title == title).FirstOrDefaultAsync();
        }

        public void Updatemovie(Movie movieToUpdate, Movie updatedMovie)
        {
            //MockDataBase.UpdateMovie(movieToUpdate.Id, updatedMovie);
        }
    }
}
