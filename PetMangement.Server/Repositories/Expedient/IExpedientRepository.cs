using PetMangement.Server.Models;

namespace PetMangement.Server.Repositories.Expedient
{
    public interface IExpedientRepository
    {
        /// <summary>
        /// Get all expedient of one record from Pet
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public ExpedientModel GetExpedientByPetId(int petId);
    }
}
