using StreamingService.Model;
using StreamingService.Repository;

namespace StreamingService.Services
{
    public class MovieService
    {
        IMovieRepository repo = new MovieRepository();

        public void doStuff()
        {
            repo.AddMovie(new Movie(
                12, "JHFGASD", "Drama", 1992, "Me", 10));
        }    
     

        public void PrintAllMovies()
        {
            List<Movie> movies = repo.GetAllMovies();
            foreach (var movie in movies)
            {
                Console.WriteLine($"Id: {movie.Id}, Title: {movie.Title}, Genre: {movie.Genre}, Release Year: {movie.ReleaseYear}, Director: {movie.Director}, Rating: {movie.Rating}");
            }
        }

    }
}
