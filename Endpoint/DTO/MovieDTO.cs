using StreamingService.Model;

namespace StreamingService.Endpoint.DTO;

public class MovieDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }


    public MovieDTO(){ }
    public MovieDTO(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        Genre = movie.Genre;
    }
}