using MongoDB.Bson;
using StreamingService.Model;

namespace StreamingService.Repository
{
    public interface IMovieRepository
    {
        Task<ObjectId> AddMovieAsync(Stream stream, string fileName, string fileType);
        
        Task<Movie?> SearchMovieAsync(string input);

        Task<(Stream Stream, string ContentType, string FileName)> GetMovieStreamAsync(string fileName);
        /*
        List<Movie> GetAllMovies();
*/

    }
}
