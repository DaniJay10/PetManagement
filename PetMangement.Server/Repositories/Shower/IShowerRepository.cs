using PetMangement.Server.Models;

namespace PetMangement.Server.Repositories.Shower
{
    public interface IShowerRepository
    {
        /// <summary>
        /// Get all records from shower
        /// </summary>
        /// <returns></returns>
        public List<ShowerModel> GetShowers();

        /// <summary>
        /// Get a specific record from shower
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        public ShowerModel GetShowerById(int showerId);

        /// <summary>
        /// Create one shower record
        /// </summary>
        /// <param name="Shower"></param>
        /// <returns></returns>
        public bool CreateShower(ShowerModel Shower);

        /// <summary>
        /// Update one shower record
        /// </summary>
        /// <param name="Shower"></param>
        /// <returns></returns>
        public bool UpdateShower(ShowerModel Shower);

        /// <summary>
        /// Delete one shower record
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        public bool DeleteShower(int showerId);
    }
}
