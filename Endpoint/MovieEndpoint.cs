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
                return movie;
            }).WithName("GetMovie");
            
            
            return endpoints;
        }
    }
}