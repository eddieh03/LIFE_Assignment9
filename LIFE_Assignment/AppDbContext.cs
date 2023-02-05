using MongoDB.Driver;

namespace LIFE_Assignment
{
    public class AppDbContext 
    {
        private readonly IMongoDatabase _database;
        public AppDbContext(IMongoClient mongoClient)
        {
            var connectionString = System.Environment.GetEnvironmentVariable("ConnectionString");

            _database = mongoClient.GetDatabase("PetDatabase");
        }

        public IMongoCollection<Pet> Pets => _database.GetCollection<Pet>("Pets");
    }
}
