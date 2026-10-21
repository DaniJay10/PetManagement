using PetMangement.Server.Models;

namespace PetMangement.Server.Repositories.Pet
{
    public interface IPetRepository
    {
        /// <summary>
        /// Get all records from pet
        /// </summary>
        /// <returns></returns>
        public List<PetModel> GetPets();

        /// <summary>
        /// Get specific record from pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PetModel GetPetById(int id);

        /// <summary>
        /// Record one pet
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        public bool CreatePet(PetModel Pet);

        /// <summary>
        /// Update one record from pet
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        public bool UpdatePet(PetModel Pet);

        /// <summary>
        /// Delete one record from pet
        /// </summary>
        /// <param name="PetId"></param>
        /// <returns></returns>
        public bool DeletePet(int PetId);
    }
}
