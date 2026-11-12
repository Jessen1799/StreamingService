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

            //var database = testClient.GetDatabase("dbStreaming");

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


        /// <summary>
        /// Retrieves a movie from MongoDB GridFS and returns it as a readable stream.
        /// The movie data is retrieved from the GridFS chunks collection (fs.chunks)
        /// as the stream is read, avoiding the need to load the entire file into memory.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<(Stream Stream, string ContentType, string FileName)> GetMovieStreamAsync(string fileName)
        {
            // Create a filter to find the movie in the GridFS files collection (fs.files)
            var filter = Builders<GridFSFileInfo>.Filter.Eq(
                movie => movie.Filename,
                fileName
            );

            // Execute the query and retrieve the first matching file.
            var queryResult = await (await _bucket.FindAsync(filter))
                .FirstOrDefaultAsync();

            // Check whether the requested movie exists in GridFS.
            if (queryResult == null)
            {
                // Return null values if the file cannot be found.
                return (null, null, null);
            }

            var downloadStream = await _bucket.OpenDownloadStreamAsync(queryResult.Id);

            // Retrieve the movie's content type from its metadata.
            var contentType = queryResult.Metadata?.Contains("contentType") == true
                ? queryResult.Metadata["contentType"].AsString
                : "application/octet-stream";

            // Return the download stream, content type and original filename.
            return (downloadStream, contentType, queryResult.Filename);
        }
    }
}
