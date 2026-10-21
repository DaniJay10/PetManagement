using PetMangement.Server.DTOs.Pet;
using PetMangement.Server.Models;

namespace PetMangement.Server.Services.Pet
{
    /// <summary>
    /// Get all the records from the DB
    /// </summary>
    /// <returns></returns>
    public interface IPetService
    {
        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<PetModel> GetPets();

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public PetModel GetPetById(int petId);

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        public bool CreatePet(CreatePetDTO pet);

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        public bool UpdatePet(UpdatePetDTO pet);

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public bool DeletePet(int petId);
    }


}
