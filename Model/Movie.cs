using MongoDB.Bson.Serialization.Attributes;

namespace StreamingService.Model
{
    public class Movie
    {
        [BsonId]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileLength { get; set; }
        public string FileType { get; set; }


        public Movie(int id, string fileName, string fileLength, string fileType)
        {
            Id = id;
            FileName = fileName;
            FileLength = fileLength;
            FileType = fileType;
        }
    }
}
