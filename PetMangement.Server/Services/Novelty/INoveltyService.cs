using PetMangement.Server.DTOs.Novelty;
using PetMangement.Server.Models;

namespace PetMangement.Server.Services.Novelty
{
    public interface INoveltyService
    {
        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        List<NoveltyModel> GetNovelties();

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <returns></returns>
        NoveltyModel GetNoveltyById(int noveltyId);

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="novelty"></param>
        /// <returns></returns>
        bool CreateNovelty(CreateNoveltyDTO novelty);

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="novelty"></param>
        /// <returns></returns>
        bool UpdateNovelty(UpdateNoveltyDTO novelty);

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <returns></returns>
        bool DeleteNovelty(int noveltyId);
    }
}