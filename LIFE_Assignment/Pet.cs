using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LIFE_Assignment
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        
    }
}
