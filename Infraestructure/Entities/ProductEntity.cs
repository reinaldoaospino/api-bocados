using MongoDB.Bson.Serialization.Attributes;

namespace Infraestructure.Entities
{
    public class ProductEntity
    {
        [BsonId]
        public string Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public bool FeaturedProduct { get; set; }

        public string Category { get; set; }

        public byte[] Imagen { get; set; }
    }
}
