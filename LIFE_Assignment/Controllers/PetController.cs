using LIFE_Assignment.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LIFE_Assignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        { 
            _petService = petService;
        }

        [HttpGet("GetPet{id}")]
        public async Task<IActionResult> GetPet(string id)
        {
            var pet = await _petService.GetPet(id);

            if(pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        [HttpGet("GetAllPets")]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await _petService.GetAll();
            return Ok(pets);
        }


        [HttpPost("AddPet")]
        public async Task<IActionResult> AddPet([FromBody] PetDto petDto)
        {
            var pet = new Pet
            {
                Name = petDto.Name,
                Breed = petDto.Breed,
                Age = petDto.Age
            };

            var petToAdd = _petService.CreatePet(pet);

            return Ok("Created Successfully!");
        }

        [HttpPut("UpdatePet")]
        public async Task<IActionResult> UpdatePet(string id, [FromBody] PetDto petDto)
        {
            var pet = new Pet
            {
                Name = petDto.Name,
                Breed = petDto.Breed,
                Age = petDto.Age
            };

            var result = await _petService.UpdatePet(id, pet);
            return Ok(result);
        }

        [HttpDelete("DeletePet")]
        public async Task<IActionResult> DeletePet(string id)
        {
            await _petService.DeleteCar(id);
            return Ok("Pet Deleted Successfully!");
        }

        
    }
}
