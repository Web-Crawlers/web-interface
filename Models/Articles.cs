using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebCrawlerInterface.Models
{
    public class Articles
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }

        public string url { get; set; } = null!;

        public string content { get; set; } = null!;
    }
}
