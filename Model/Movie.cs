using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

﻿
namespace StreamingService.Model
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //I tvivl om dette, men autocode ting ville have det.
        private string Id { get; set; } = null!;
        public string Title { get; set; } = null!;   
        public string Category { get; set; } = null!;

        public Movie(string title, string category)
        {
            Title = title;
            Category = category;
        }
    }
}
