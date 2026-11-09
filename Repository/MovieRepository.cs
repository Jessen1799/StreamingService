using StreamingService.Model;

namespace StreamingService.Repository
{
    public class MovieRepository : IMovieRepository
    {
     
        public void AddMovie(Movie movie)
        {
            //MockDataBase.AddMovie(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            //MockDataBase.DeleteMovie(movie.Id);
        }

        List<Movie> movies;
        public List<Movie> GetAllMovies()
        {
            //return movies = MockDataBase.GetAllMovies();
            return movies;
        }

        public Movie GetMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Updatemovie(Movie movieToUpdate, Movie updatedMovie)
        {
            //MockDataBase.UpdateMovie(movieToUpdate.Id, updatedMovie);
        }
    }
}
