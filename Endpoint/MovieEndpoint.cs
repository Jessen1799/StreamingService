using StreamingService.Endpoint.DTO;
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

            endpoints.MapGet("/movie/{fileName}", async (string fileName, IMovieRepository repository) =>
            {
                var movie = await repository.SearchMovieAsync(fileName);
                
                if (movie == null)
                {
                    return Results.NotFound();
                }
                
                return Results.Ok(new MovieDTO(movie));
            });
            
            
            endpoints.MapGet("/movies/stream/{fileName}", async (string fileName, IMovieRepository repository, 
                    ILogger<Program> logger) =>
                {
                    logger.LogInformation("Movie streaming endpoint called for: {FileName}", fileName);

                    var (stream, contentType, fileNameResult) =
                        await repository.GetMovieStreamAsync(fileName);

                    if (stream == null)
                    {
                        logger.LogWarning("Movie not found in GridFS: {FileName}", fileName);

                        return Results.NotFound(new
                        {
                            message = $"Movie '{fileName}' not found."
                        });
                    }

                    logger.LogInformation("Movie found. Streaming: {FileName}", fileNameResult);

                    return Results.Stream(
                        stream,
                        contentType: contentType,
                        enableRangeProcessing: true
                    );
                })
                .WithName("StreamMovieFile");
            
            return endpoints;
        }
        
    }
}