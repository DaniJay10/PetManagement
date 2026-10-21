using PetMangement.Server.DTOs.Consultation;
using PetMangement.Server.Models;

namespace PetMangement.Server.Services.Consultation
{
    public interface IConsultationService
    {
        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<ConsultationModel> GetConsultations();

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        public ConsultationModel GetConsultationById(int consultationId);

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public bool CreateConsultation(CreateConsultDTO consultation);

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public bool UpdateConsultation(UpdateConsultDTO consultation);

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        public bool DeleteConsultation(int consultationId);
    }
}
