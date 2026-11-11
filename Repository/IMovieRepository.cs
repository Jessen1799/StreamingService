using MongoDB.Bson;
using StreamingService.Model;

namespace StreamingService.Repository
{
    public interface IMovieRepository
    {
        Task<ObjectId> AddMovieAsync(Stream stream, string fileName, string fileType);
        
        Task<Movie> SearchMovieAsync(string input);
        /*
        List<Movie> GetAllMovies();
*/

    }
}
