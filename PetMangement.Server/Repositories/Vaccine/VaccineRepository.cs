using PetMangement.Server.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PetMangement.Server.Repositories.Vaccine
{
    public class VaccineRepository(IConfiguration configuration) : IVaccineRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("ConnectionString");

        // <summary>
        /// Get all records from Vaccine
        /// </summary>
        /// <returns></returns>
        public List<VaccineModel> GetVaccines()
        {
            var vaccinesList = new List<VaccineModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_VACCINE_GETALL", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vaccinesList.Add(new VaccineModel
                        {
                            vaccineId = Convert.ToInt32(dr["vaccineId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            vaccineType = dr["vaccineType"].ToString(),
                            applicationDate = Convert.ToDateTime(dr["applicationDate"]),
                        });
                    }
                }

                return vaccinesList;
            }
        }

        /// <summary>
        /// Get specific record from vaccine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VaccineModel GetVaccineById(int vaccineId)
        {
            var vaccine = new VaccineModel();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_VACCINE_GET_BY_ID", connection);
                cmd.Parameters.AddWithValue("@vaccineId", vaccineId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vaccine.vaccineId = Convert.ToInt32(dr["vaccineId"]);
                        vaccine.petId = Convert.ToInt32(dr["petId"]);
                        vaccine.vaccineType = dr["vaccineType"].ToString();
                        vaccine.applicationDate = Convert.ToDateTime(dr["applicationDate"]);
                    }
                }

                return vaccine;
            }
        }

        /// <summary>
        /// Record one record of vaccine
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        public bool CreateVaccine(VaccineModel vaccine)
        {
            var saveVaccine = false;

            try
            {

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_VACCINE_CREATE", connection);

                    cmd.Parameters.AddWithValue("@PetId", vaccine.petId);
                    cmd.Parameters.AddWithValue("@VaccineType", vaccine.vaccineType);
                    cmd.Parameters.AddWithValue("@ApplicationDate", vaccine.applicationDate);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                saveVaccine = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveVaccine = false;
            }

            return saveVaccine;
        }

        /// <summary>
        /// Update one record from vaccine
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        public bool UpdateVaccine(VaccineModel vaccine)
        {
            var saveVaccine = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_VACCINE_UPDATE", connection);

                    cmd.Parameters.AddWithValue("@vaccineId", vaccine.vaccineId);
                    cmd.Parameters.AddWithValue("@PetId", vaccine.petId);
                    cmd.Parameters.AddWithValue("@VaccineType", vaccine.vaccineType);
                    cmd.Parameters.AddWithValue("@ApplicationDate", vaccine.applicationDate);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                saveVaccine = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveVaccine = false;
            }

            return saveVaccine;
        }

        /// <summary>
        /// Delete one record of consultation
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        public bool DeleteVaccine(int vaccineId)
        {
            var vaccineDelete = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_VACCINE_DELETE", connection);
                    cmd.Parameters.AddWithValue("@vaccineId", vaccineId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                vaccineDelete = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                vaccineDelete = false;
            }

            return vaccineDelete;
        }
    }
}
