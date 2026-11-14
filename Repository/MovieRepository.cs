using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using StreamingService.Model;

namespace StreamingService.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly GridFSBucket _bucket;

        /// <summary>
        /// When constructor is used a GridFSBucket object is ready to be used with our database
        /// configurations.
        /// </summary>
        public MovieRepository()
        {
            var connectionString = "mongodb://localhost:27017/";
            var testClient = new MongoClient(connectionString);

            _bucket = new GridFSBucket(testClient.GetDatabase("dbStreaming"));
        }


        /// <summary>
        /// Method for upload of a stream into mongo db asynchronous.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        public async Task AddMovieAsync(Stream stream, string fileName)
        {
            await _bucket.UploadFromStreamAsync(fileName, stream);
        }


        /// <summary>
        /// Method searches in MongoDB for a movie based off filename and method invokers input.
        /// Returns movie in mongodb format 'GridFSFileInfo' and is converted into a Movie.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method uses an empty filter to gather all movie meta data.
        /// Uses Cursor to go through the collection -> Each document is being added to a list.
        /// </summary>
        /// <returns></returns>
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