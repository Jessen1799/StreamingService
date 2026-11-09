using StreamingService.Model;

namespace StreamingService.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        Task<Movie> GetMovie(string title);
        void DeleteMovie(Movie movie);
        void Updatemovie(Movie movieToUpdate, Movie updatedMovie);
        List<Movie> GetAllMovies();

    }
}
