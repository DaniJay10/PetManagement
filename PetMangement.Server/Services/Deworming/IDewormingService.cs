using PetMangement.Server.DTOs.Deworming;
using PetMangement.Server.Models;

namespace PetMangement.Server.Services.Deworming
{
    public interface IDewormingService
    {
        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        List<DewormingModel> GetDewormings();

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <returns></returns>
        DewormingModel GetDewormingById(int dewormingId);

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="deworming"></param>
        /// <returns></returns>
        bool CreateDeworming(CreateDewormingDTO deworming);

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="deworming"></param>
        /// <returns></returns>
        bool UpdateDeworming(UpdateDewormingDTO deworming);

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <returns></returns>
        bool DeleteDeworming(int dewormingId);
    }
}