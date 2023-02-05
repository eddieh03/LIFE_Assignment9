using MongoDB.Driver;

namespace LIFE_Assignment.Services
{
    public class PetService : IPetService
    {
        private readonly AppDbContext _context;

        public PetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreatePet(Pet pet)
        {
            await _context.Pets.InsertOneAsync(pet);    
        }

        public async Task<bool> DeleteCar(string id)
        {
            var filter = Builders<Pet>.Filter.Eq("ID", id);
            var result = await _context.Pets.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _context.Pets.Find(_ => true).ToListAsync();
        }

        public async Task<Pet> GetPet(string id)
        {
            var filters = Builders<Pet>.Filter.Eq("ID", id);
            return await _context.Pets.Find(filters).FirstOrDefaultAsync();
        }

        public async  Task<bool> UpdatePet(string id, Pet pet)
        {
            var filters = Builders<Pet>.Filter.Eq("ID", id);
            var update = Builders<Pet>.Update
                                .Set(r => r.Name, pet.Name)
                                .Set(r => r.Breed, pet.Breed)
                                .Set(r => r.Age, pet.Age);
                                
            var result = await _context.Pets.UpdateOneAsync(filters, update);

            return result.IsAcknowledged;
        }
    }
}
