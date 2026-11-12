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
            var testClient = new MongoClient(connectionString);

            _bucket = new GridFSBucket(testClient.GetDatabase("dbStreaming"));
        }


        public async Task AddMovieAsync(Stream stream, string fileName)
        {
            await _bucket.UploadFromStreamAsync(fileName, stream);
        }


        public async Task<Movie?> SearchMovieAsync(string input)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq("filename", input);
            
            GridFSFileInfo queryResult = await _bucket.Find(filter).FirstOrDefaultAsync();
            
            if (queryResult == null)
            {
                return null;
            }

            return new Movie(queryResult.Id, queryResult.Filename, queryResult.Length);
        }

        public async Task<List<GridFSFileInfo>> GetAllMovies()
        {
            //Type: Object that hold info about a stored fs.files
            List<GridFSFileInfo> result = new();
            
            var filter = Builders<GridFSFileInfo>.Filter.Empty;

            //MongoDB uses a cursor to go through a collection. Mechanism that gives us acces to go through the entire collection
            using IAsyncCursor<GridFSFileInfo> cursor = await _bucket.FindAsync(filter);

            //All documents cursor navigates through is simply put in our list.
            result = await cursor.ToListAsync();

            return result;
        }
    }
}