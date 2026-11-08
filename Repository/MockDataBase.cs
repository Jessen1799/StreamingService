using StreamingService.Model;

namespace StreamingService.Repository
{
    public static class MockDataBase
    {

        static List<Movie> movies = new List<Movie>()
        {
            new Movie(1, "The Shawshank Redemption", "Drama", 1994, "Frank Darabont", 9.3),
            new Movie(2, "The Godfather", "Crime", 1972, "Francis Ford Coppola", 9.2),
            new Movie(3, "The Dark Knight", "Action", 2008, "Christopher Nolan", 9.0),
            new Movie(4, "Pulp Fiction", "Crime", 1994, "Quentin Tarantino", 8.9),
            new Movie(5, "Forrest Gump", "Drama", 1994, "Robert Zemeckis", 8.8),
            new Movie(6, "Inception", "Sci-Fi", 2010, "Christopher Nolan", 8.8),
        };

        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public static Movie GetMovieById(int id)
        {
            return movies.FirstOrDefault(movie => movie.Id == id);
        }

        public static List<Movie> GetAllMovies()
        {
            return movies;
        }

        public static void DeleteMovie(int id)
        {
            var movieToDelete = movies.FirstOrDefault(movie => movie.Id == id);
            if (movieToDelete != null)
            {
                movies.Remove(movieToDelete);
            }
        }

        public static void UpdateMovie(int id, Movie updatedMovie)
        {
            var movieToUpdate = movies.FirstOrDefault(movie => movie.Id == id);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = updatedMovie.Title;
                movieToUpdate.Genre = updatedMovie.Genre;
                movieToUpdate.ReleaseYear = updatedMovie.ReleaseYear;
                movieToUpdate.Director = updatedMovie.Director;
                movieToUpdate.Rating = updatedMovie.Rating;
            }
        }
    }
}
