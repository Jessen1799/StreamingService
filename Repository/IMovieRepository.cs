using StreamingService.Model;

namespace StreamingService.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        Task<Movie> GetMovie(string title);
        List<Movie> GetAllMovies();

    }
}
