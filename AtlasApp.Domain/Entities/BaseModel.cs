using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AtlasApp.Domain.Entities
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
    }
}