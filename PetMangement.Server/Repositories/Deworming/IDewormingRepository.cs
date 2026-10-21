using PetMangement.Server.Models;

namespace PetMangement.Server.Repositories.Deworming
{
    public interface IDewormingRepository
    {
        // <summary>
        /// Get all records from deworming
        /// </summary>
        /// <returns></returns>
        public List<DewormingModel> GetDewormings();

        /// <summary>
        /// Get specific record from deworming
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DewormingModel GetDewormingById(int dewormingId);

        /// <summary>
        /// Record one record of deworming
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        public bool CreateDeworming(DewormingModel deworming);

        /// <summary>
        /// Update one record from deworming
        /// </summary>
        /// <param name="deworming"></param>
        /// <returns></returns>
        public bool UpdateDeworming(DewormingModel deworming);

        /// <summary>
        /// Delete one record of deworming
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <returns></returns>
        public bool DeleteDeworming(int dewormingId);
    }
}
