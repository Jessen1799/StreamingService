using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StreamingService.Model
{
    public class Movie
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string FileName { get; set; }
        public int FileLength { get; set; }
        public string FileType { get; set; }


        public Movie(ObjectId id, string fileName, int fileLength, string fileType)
        {
            Id = id;
            FileName = fileName;
            FileLength = fileLength;
            FileType = fileType;
        }
    }
}
