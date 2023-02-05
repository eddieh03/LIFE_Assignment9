namespace LIFE_Assignment.Services
{
    public interface IPetService
    {
        Task CreatePet(Pet pet);
        Task<bool> DeleteCar(string id);
        Task<List<Pet>> GetAll();
        Task<Pet> GetPet(string id);
        Task<bool> UpdatePet(string id, Pet pet);
    }
}