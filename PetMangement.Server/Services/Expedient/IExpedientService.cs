using PetMangement.Server.Models;

namespace PetMangement.Server.Services.Expedient
{
    public interface IExpedientService
    {
        /// <summary>
        /// Get all expedient of one record from Pet
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public ExpedientModel GetExpedientByPetId(int petId);
    }
}
