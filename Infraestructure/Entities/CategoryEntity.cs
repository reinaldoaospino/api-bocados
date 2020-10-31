using MongoDB.Bson.Serialization.Attributes;

namespace Infraestructure.Entities
{
    public class CategoryEntity
    {
        [BsonId]
        public string Id { get; set; }

        public string CategoryName { get; set; }
    }
}
