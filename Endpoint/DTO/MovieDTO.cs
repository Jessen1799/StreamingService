using MongoDB.Bson;
using StreamingService.Model;

namespace StreamingService.Endpoint.DTO;

public class MovieDTO
{
    public ObjectId Id { get; set; }
    public string FileName { get; set; }
    public long FileLength { get; set; }

    public MovieDTO(){ }

    public MovieDTO(Movie movie)
    {
        Id = movie.Id;
        FileName = movie.FileName;
        FileLength = movie.FileLength;
    }
    
}