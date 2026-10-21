using PetMangement.Server.DTOs.Consultation;
using PetMangement.Server.Models;
using PetMangement.Server.Repositories.Consultation;

namespace PetMangement.Server.Services.Consultation
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _repository;

        public ConsultationService(IConsultationRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<ConsultationModel> GetConsultations()
        {
            return _repository.GetConsultations();
        }

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        public ConsultationModel GetConsultationById(int consultationId)
        {
            return _repository.GetConsultationById(consultationId);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public bool CreateConsultation(CreateConsultDTO consultation)
        {
            var consultModel = new ConsultationModel
            {
                petId = consultation.petId,
                reason = consultation.reason,
                diagnosis = consultation.diagnosis,
                notes = consultation.notes,
                consultationDate = consultation.consultationDate,
            };

            return _repository.CreateConsultation(consultModel);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public bool UpdateConsultation(UpdateConsultDTO consultation)
        {
            var consultModel = new ConsultationModel
            {
                consultationId = consultation.consultationId,
                petId = consultation.petId,
                reason = consultation.reason,
                diagnosis = consultation.diagnosis,
                notes = consultation.notes,
                consultationDate = consultation.consultationDate,
            };

            return _repository.UpdateConsultation(consultModel);
        }

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        public bool DeleteConsultation(int consultationId)
        {
            return _repository.DeleteConsultation(consultationId);
        }
    }
}
