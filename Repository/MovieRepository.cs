using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using StreamingService.Model;

namespace StreamingService.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMongoCollection<Movie> _movies;
        private readonly GridFSBucket _bucket;

        public MovieRepository()
        {
            var connectionString = "mongodb://localhost:27017/";

            MongoClient testClient = new MongoClient(connectionString);

            var database = testClient.GetDatabase("dbStreaming");

            _movies = database.GetCollection<Movie>("Movies");

            _bucket = new GridFSBucket(testClient.GetDatabase("dbStreaming"));
        }

        public async Task<ObjectId> AddMovieAsync(Stream stream, string fileName, string fileType)
        {
            //Sur på id, fordi det er en int, men den vil have bsonværdi?
            //forkert metode forsøgt................ Skulle uploade ikke downloade
            var id = await _bucket.UploadFromStreamAsync(fileName, stream);
            return id; //ObjectId
        }
/*
        public List<Movie> GetAllMovies()
        {
            var filter = Builders<Movie>.Filter.Empty;
            return _movies.Find(filter).ToList();
        }

        public async Task<Movie> GetMovie(string title)
        {
            return await _movies.Find(m => m.Title == title).FirstOrDefaultAsync();
        }
    }
    */
    }
}