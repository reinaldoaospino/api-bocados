using MongoDB.Bson.Serialization.Attributes;

namespace Infraestructure.Entities
{
    public class UserEntity
    {
        [BsonId]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
