using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PLAY.CATALOG.src.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}