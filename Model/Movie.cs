using MongoDB.Bson.Serialization.Attributes;

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
            this.Id = id;
            this.Title = title;
            this.Genre = genre;
        }
    }
}
