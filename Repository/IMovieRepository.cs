using StreamingService.Model;

namespace StreamingService.Repository
{
    public interface IMovieRepository
    {
        Task AddMovieAsync(Stream stream, string fileName);
        
        Task<Movie?> SearchMovieAsync(string input);
        /*
        List<Movie> GetAllMovies();
*/

    }
}
