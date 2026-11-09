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
        public List<Movie> GetAllMovies()
        {
            var filter = Builders<Movie>.Filter.Empty;
            return _movies.Find(filter).ToList();
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
