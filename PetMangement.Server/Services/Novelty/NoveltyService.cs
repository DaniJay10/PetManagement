using PetMangement.Server.DTOs.Novelty;
using PetMangement.Server.Models;
using PetMangement.Server.Repositories.Novelty;

namespace PetMangement.Server.Services.Novelty
{
    public class NoveltyService : INoveltyService
    {
        private readonly INoveltyRepository _repository;

        public NoveltyService(INoveltyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<NoveltyModel> GetNovelties()
        {
            return _repository.GetNovelties();
        }

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <returns></returns>
        public NoveltyModel GetNoveltyById(int noveltyId)
        {
            return _repository.GetNoveltyById(noveltyId);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="novelty"></param>
        /// <returns></returns>
        public bool CreateNovelty(CreateNoveltyDTO novelty)
        {
            var noveltyModel = new NoveltyModel
            {
                petId = novelty.petId,
                noveltyDate = novelty.noveltyDate,
                description = novelty.description
            };

            return _repository.CreateNovelty(noveltyModel);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="novelty"></param>
        /// <returns></returns>
        public bool UpdateNovelty(UpdateNoveltyDTO novelty)
        {
            var noveltyModel = new NoveltyModel
            {
                noveltyId = novelty.noveltyId,
                petId = novelty.petId,
                noveltyDate = novelty.noveltyDate,
                description = novelty.description
            };

            return _repository.UpdateNovelty(noveltyModel);
        }

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <returns></returns>
        public bool DeleteNovelty(int noveltyId)
        {
            return _repository.DeleteNovelty(noveltyId);
        }
    }
}