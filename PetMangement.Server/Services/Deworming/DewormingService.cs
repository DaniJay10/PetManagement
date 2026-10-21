using PetMangement.Server.DTOs.Deworming;
using PetMangement.Server.Models;
using PetMangement.Server.Repositories.Deworming;

namespace PetMangement.Server.Services.Deworming
{
    public class DewormingService : IDewormingService
    {
        private readonly IDewormingRepository _repository;

        public DewormingService(IDewormingRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<DewormingModel> GetDewormings()
        {
            return _repository.GetDewormings();
        }

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <returns></returns>
        public DewormingModel GetDewormingById(int dewormingId)
        {
            return _repository.GetDewormingById(dewormingId);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="deworming"></param>
        /// <returns></returns>
        public bool CreateDeworming(CreateDewormingDTO deworming)
        {
            var dewormingModel = new DewormingModel
            {
                petId = deworming.petId,
                applicationDate = deworming.applicationDate
            };

            return _repository.CreateDeworming(dewormingModel);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="deworming"></param>
        /// <returns></returns>
        public bool UpdateDeworming(UpdateDewormingDTO deworming)
        {
            var dewormingModel = new DewormingModel
            {
                dewormingId = deworming.dewormingId,
                petId = deworming.petId,
                applicationDate = deworming.applicationDate
            };

            return _repository.UpdateDeworming(dewormingModel);
        }

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <returns></returns>
        public bool DeleteDeworming(int dewormingId)
        {
            return _repository.DeleteDeworming(dewormingId);
        }
    }
}