using PetMangement.Server.DTOs.Vaccine;
using PetMangement.Server.Models;
using PetMangement.Server.Repositories.Vaccine;

namespace PetMangement.Server.Services.Vaccine
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _repository;

        public VaccineService(IVaccineRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<VaccineModel> GetVaccines()
        {
            return _repository.GetVaccines();
        }

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="vaccineId"></param>
        /// <returns></returns>
        public VaccineModel GetVaccineById(int vaccineId)
        {
            return _repository.GetVaccineById(vaccineId);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        public bool CreateVaccine(CreateVaccineDTO vaccine)
        {
            var vaccineModel = new VaccineModel
            {
                petId = vaccine.petId,
                vaccineType = vaccine.vaccineType,
                applicationDate = vaccine.applicationDate
            };

            return _repository.CreateVaccine(vaccineModel);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public bool UpdateVaccine(UpdateVaccineDTO vaccine)
        {
            var vaccineModel = new VaccineModel
            {
                vaccineId = vaccine.vaccineId,
                petId = vaccine.petId,
                vaccineType = vaccine.vaccineType,
                applicationDate = vaccine.applicationDate
            };

            return _repository.UpdateVaccine(vaccineModel);
        }

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="vaccineId"></param>
        /// <returns></returns>
        public bool DeleteVaccine(int vaccineId)
        {
            return _repository.DeleteVaccine(vaccineId);
        }
    }
}
