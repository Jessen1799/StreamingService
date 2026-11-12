using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StreamingService.Endpoint.DTO;

namespace StreamingService.Model
{
    public class Movie
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }


        public Movie(MovieDTO movieDto)
        {
            Id = movieDto.Id;
            FileName = movieDto.FileName;
            FileLength = movieDto.FileLength;
        }
        public Movie(ObjectId movieId, string fileName, long fileLength)
        {
            Id = movieId;
            FileName = fileName;
            FileLength = fileLength;
        }

        public Movie() { }
    }
}
