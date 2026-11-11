using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using StreamingService.Model;

namespace StreamingService.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly GridFSBucket _bucket;

        public MovieRepository()
        {
            var connectionString = "mongodb://localhost:27017/";

            MongoClient testClient = new MongoClient(connectionString);

            var database = testClient.GetDatabase("dbStreaming");

            _bucket = new GridFSBucket(testClient.GetDatabase("dbStreaming"));
        }

        public async Task<ObjectId> AddMovieAsync(Stream stream, string fileName, string fileType)
        {
            var id = await _bucket.UploadFromStreamAsync(fileName, stream);
            return id;
        }

        public async Task<Movie?> SearchMovieAsync(string input)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq("filename", input);
            
            var queryResult = await _bucket.Find(filter).FirstOrDefaultAsync();

            if (queryResult == null)
            {
                return null;
            }
            
            return new Movie(queryResult.Id, queryResult.Filename, queryResult.Length);
        }
    }
}
