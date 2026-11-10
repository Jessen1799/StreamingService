using StreamingService.Endpoint.DTO;
using StreamingService.Model;
using StreamingService.Repository;

namespace StreamingService.Endpoint
{
    public static class MovieEndpoint
    {
        public static IEndpointRouteBuilder MapMovieEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/movie/{Title}", async (string title, IMovieRepository repository) =>
            {
                var movie = await repository.GetMovie(title);
                
                return Results.Ok(new MovieDTO(movie));
                
            }).WithName("GetSpecificMovie");
            
            
            endpoints.MapGet("/movies", (IMovieRepository repository) =>
            {
                List<Movie> allMovies = repository.GetAllMovies();
                
                return Results.Ok(allMovies);
                
            }).WithName("GetAllMovies");

            endpoints.MapPost("/movie", (MovieDTO movie, IMovieRepository repository) =>
            {
                repository.AddMovie(new Movie(movie));

                return Results.Ok(movie);
            });
            //Return all endpoints
            return endpoints;
        }
    }
}