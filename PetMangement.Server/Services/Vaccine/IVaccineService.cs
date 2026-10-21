using PetMangement.Server.DTOs.Vaccine;
using PetMangement.Server.Models;

namespace PetMangement.Server.Services.Vaccine
{
    public interface IVaccineService
    {
        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<VaccineModel> GetVaccines();

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="vaccineId"></param>
        /// <returns></returns>
        public VaccineModel GetVaccineById(int vaccineId);

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        public bool CreateVaccine(CreateVaccineDTO vaccine);

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="vaccineId"></param>
        /// <returns></returns>
        public bool DeleteVaccine(int vaccineId);
    }
}
