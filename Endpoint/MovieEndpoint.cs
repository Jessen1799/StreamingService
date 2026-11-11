using StreamingService.Model;
using StreamingService.Repository;

namespace StreamingService.Endpoint
{
    public static class MovieEndpoint
    {
        public static IEndpointRouteBuilder MapMovieEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/movie", async (IFormFile file, IMovieRepository repository) =>
            {
                var uploadStream = file.OpenReadStream();

                var id = await repository.AddMovieAsync(uploadStream, file.FileName, file.ContentType);

                return Results.Ok(new
                {
                    Id = id.ToString(),
                    FileName = file.FileName,
                    FileType = file.ContentType,
                    FileLength = file.Length
                });

            }).DisableAntiforgery(); //Feljkode 500 internal server error uden. Noget med at endpointet indeholder anti forgery metadata, og der skal være middleware eller sådan noget. Slår bare alt fra i form af sikkerhed omkring det vil jeg tro.
            
            return endpoints;

            /*
            endpoints.MapGet("/movies", (IMovieRepository repository) =>
            {
                List<Movie> allMovies = repository.GetAllMovies();

                return Results.Ok(allMovies);

            }).WithName("GetAllMovies");

            endpoints.MapPost("/movie", (Movie movie, IMovieRepository repository) =>
            {
                repository.AddMovie(movie);

                return Results.Ok(movie);
            });
            //Return all endpoints*/
            
        }
    }
}