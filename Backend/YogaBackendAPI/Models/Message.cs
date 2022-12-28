using System;
using System.Diagnostics.CodeAnalysis;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YogaBackendAPI.Models
{
    // Database Model
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text {get; set;}
        public string MailCustomer {get; set;}
        public string NameCustomer {get; set;}
        
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date {get; set;}

        
    }
}