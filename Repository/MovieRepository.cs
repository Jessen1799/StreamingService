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
            var testClient = new MongoClient(connectionString);
            
            _bucket = new GridFSBucket(testClient.GetDatabase("dbStreaming"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task AddMovieAsync(Stream stream, string fileName)
        {
            await _bucket.UploadFromStreamAsync(fileName, stream); 
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
