using PetMangement.Server.Models;
using PetMangement.Server.Repositories.Expedient;

namespace PetMangement.Server.Services.Expedient
{
    public class ExpedientService : IExpedientService
    {
        private readonly IExpedientRepository _repository;

        public ExpedientService(IExpedientRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all expedient of one record from Pet
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public ExpedientModel GetExpedientByPetId(int petId)
        {
            return _repository.GetExpedientByPetId(petId);
        }
    }
}
