using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StreamingService.Model
{
    public class Movie
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }


        public Movie(ObjectId id, string fileName, long fileLength)
        {
            Id = id;
            FileName = fileName;
            FileLength = fileLength;
        }
    }
}
