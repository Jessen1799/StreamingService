using MongoDB.Driver.GridFS;
using StreamingService.DTO;
using StreamingService.Model;
using StreamingService.Repository;

namespace StreamingService.Endpoint
{
    public static class MovieEndpoint
    {
        public static IEndpointRouteBuilder MapMovieEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/movie/upload", async (IFormFile file, IMovieRepository repository) =>
            {
                var uploadStream = file.OpenReadStream();
                
                await repository.AddMovieAsync(uploadStream, file.FileName);

                return Results.Ok(new ResponseDTO(file.FileName, "Success uploading your movie"));

            }).DisableAntiforgery(); //Feljkode 500 internal server error uden. Noget med at endpointet indeholder anti forgery metadata, og der skal være middleware eller sådan noget. Slår bare alt fra i form af sikkerhed omkring det vil jeg tro.

            
            endpoints.MapGet("/movie/{fileName}", async (string fileName, IMovieRepository repository) =>
            {
                var movie = await repository.SearchMovieAsync(fileName);
                
                if (movie == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(movie);
            });

            endpoints.MapGet("/movie/getall", async (IMovieRepository repository) =>
            {
                List<Movie> result = new List<Movie>();
                
                List<GridFSFileInfo> resultFromDB = await repository.GetAllMovies();

                foreach (var document in resultFromDB)
                {
                    Movie movie = new Movie(document.Id, document.Filename, document.Length);

                    result.Add(movie);
                }
                
                return Results.Ok(result);
            });
            
            
            return endpoints;
        }
    }
}