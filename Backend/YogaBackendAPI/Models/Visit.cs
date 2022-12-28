using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YogaBackendAPI.Models
{
    public class Visit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date {get; set; }

        public string ComponentName {get; set; }
    }
}