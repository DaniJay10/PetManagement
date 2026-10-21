using PetMangement.Server.Models;

namespace PetMangement.Server.Repositories.Consultation
{
    public interface IConsultationRepository
    {
        /// <summary>
        /// Get all records from Consultation
        /// </summary>
        /// <returns></returns>
        public List<ConsultationModel> GetConsultations();

        /// <summary>
        /// Get specific record from consultation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ConsultationModel GetConsultationById(int consultationId);

        /// <summary>
        /// Record one consult
        /// </summary>
        /// <param name="Consultation"></param>
        /// <returns></returns>
        public bool CreateConsultation(ConsultationModel consultation);

        /// <summary>
        /// Update one record from consultation
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public bool UpdateConsultation(ConsultationModel consultation);

        /// <summary>
        /// Delete one record from consultation
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        public bool DeleteConsultation(int consultationId);
    }
}
