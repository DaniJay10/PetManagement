using PetMangement.Server.DTOs.Shower;
using PetMangement.Server.Models;
using PetMangement.Server.Repositories.Shower;

namespace PetMangement.Server.Services.Shower
{
    public class ShowerService : IShowerService
    {
        private readonly IShowerRepository _repository;

        public ShowerService(IShowerRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<ShowerModel> GetShowers()
        {
            return _repository.GetShowers();
        }

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        public ShowerModel GetShowerById(int showerId)
        {
            return _repository.GetShowerById(showerId);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="shower"></param>
        /// <returns></returns>
        public bool CreateShower(CreateShowerDTO shower)
        {
            var showerModel = new ShowerModel
            {
                petId = shower.petId,
                ApplicationDate = shower.ApplicationDate
            };

            return _repository.CreateShower(showerModel);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="shower"></param>
        /// <returns></returns>
        public bool UpdateShower(UpdateShowerDTO shower)
        {
            var showerModel = new ShowerModel
            {
                showerId = shower.showerId,
                petId = shower.petId,
                ApplicationDate = shower.ApplicationDate
            };

            return _repository.UpdateShower(showerModel);
        }

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        public bool DeleteShower(int showerId)
        {
            return _repository.DeleteShower(showerId);
        }
    }
}