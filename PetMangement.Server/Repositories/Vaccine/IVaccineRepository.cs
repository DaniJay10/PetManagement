using PetMangement.Server.Models;

namespace PetMangement.Server.Repositories.Vaccine
{
    public interface IVaccineRepository
    {
        // <summary>
        /// Get all records from Vaccine
        /// </summary>
        /// <returns></returns>
        public List<VaccineModel> GetVaccines();

        /// <summary>
        /// Get specific record from vaccine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VaccineModel GetVaccineById(int vaccineId);

        /// <summary>
        /// Record one record of vaccine
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        public bool CreateVaccine(VaccineModel vaccine);

        /// <summary>
        /// Update one record from vaccine
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        public bool UpdateVaccine(VaccineModel vaccine);

        /// <summary>
        /// Delete one record of consultation
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        public bool DeleteVaccine(int vaccineId);
    }
}
