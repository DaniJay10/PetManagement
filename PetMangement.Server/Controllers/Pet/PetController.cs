using Microsoft.AspNetCore.Mvc;
using PetMangement.Server.DTOs.Pet;
using PetMangement.Server.Models;
using PetMangement.Server.Services.Pet;

namespace PetMangement.Server.Controllers.Pet
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

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPets()
        {
            var pets = _petService.GetPets();
            return Ok(pets);
        }

        /// <summary>
        /// Get specific record from pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{petId}")]
        public IActionResult GetPetById(int petId)
        {
            var pet = _petService.GetPet(petId);
            if (pet == null)
                return NotFound();
            return Ok(pet);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertPet([FromBody] CreatePetDTO pet)
        {
            var result = _petService.InsertPet(pet);
            if (!result)
                return BadRequest("Error al guardar");
            return StatusCode(201, result);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        [HttpPut("{petId}")]
        public IActionResult UpdatePet(int petId, [FromBody] UpdatePetDTO pet)
        {
            pet.petId = petId;
            var result = _petService.UpdatePet(pet);
            if (!result)
                return BadRequest("Error al editar");
            return Ok(result);
        }

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        [HttpDelete("{petId}")]
        public IActionResult DeletePet(int petId)
        {
            var result = _petService.DeletePet(petId);
            if (!result)
                return BadRequest("Error al eliminar");
            return Ok(result);
        }
    }
}
