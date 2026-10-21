using PetMangement.Server.DTOs.Shower;
using PetMangement.Server.Models;

namespace PetMangement.Server.Services.Shower
{
    public interface IShowerService
    {
        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<ShowerModel> GetShowers();

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        public ShowerModel GetShowerById(int showerId);

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="shower"></param>
        /// <returns></returns>
        public bool CreateShower(CreateShowerDTO shower);

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="shower"></param>
        /// <returns></returns>
        public bool UpdateShower(UpdateShowerDTO shower);

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        public bool DeleteShower(int showerId);
    }
}
