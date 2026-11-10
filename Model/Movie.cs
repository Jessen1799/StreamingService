using MongoDB.Bson.Serialization.Attributes;
using StreamingService.Endpoint.DTO;

namespace StreamingService.Model
{
    public class Movie
    {
        [BsonId]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }


        public Movie(int id, string title, string genre)
        {
            Id = id;
            Title = title;
            Genre = genre;
        }
        
        public Movie(MovieDTO movieDTO)
        {
            Id = movieDTO.Id;
            Title = movieDTO.Title;
            Genre = movieDTO.Genre;
        }
    }
}
