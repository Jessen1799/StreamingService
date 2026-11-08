using StreamingService.Model;

namespace StreamingService.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        Movie GetMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void Updatemovie(Movie movieToUpdate, Movie updatedMovie);
        List<Movie> GetAllMovies();

    }
}
