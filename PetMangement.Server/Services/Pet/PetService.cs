using PetMangement.Server.DTOs.Pet;
using PetMangement.Server.Models;
using PetMangement.Server.Repositories.Pet;

namespace PetMangement.Server.Services.Pet
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repository;

        public PetService(IPetRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<PetModel> GetPets()
        {
            return _repository.GetPets();
        }

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public PetModel GetPet(int petId) 
        {
            return _repository.GetPet(petId);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        public bool InsertPet(CreatePetDTO pet)
        {
            var petModel = new PetModel
            {
                petName = pet.petName,
                specie = pet.specie,
                breed = pet.breed,
                birthDate = pet.birthDate,
                petWeight = pet.petWeight,
                petSize = pet.petSize,
                dewormingFrequency = pet.dewormingFrequency
            };

            return _repository.InsertPet(petModel);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        public bool UpdatePet(UpdatePetDTO pet)
        {
            var petModel = new PetModel
            {
                petId = pet.petId,
                petName = pet.petName,
                specie = pet.specie,
                breed = pet.breed,
                birthDate = pet.birthDate,
                petWeight = pet.petWeight,
                petSize = pet.petSize,
                dewormingFrequency = pet.dewormingFrequency
            };

            return _repository.UpdatePet(petModel);
        }

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public bool DeletePet(int petId)
        {
            return _repository.DeletePet(petId);
        }
    }
}
