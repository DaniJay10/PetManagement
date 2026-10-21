using PetMangement.Server.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PetMangement.Server.Repositories.Deworming
{
    public class DewormingRepository(IConfiguration configuration) : IDewormingRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("ConnectionString");

        // <summary>
        /// Get all records from deworming
        /// </summary>
        /// <returns></returns>
        public List<DewormingModel> GetDewormings()
        {
            var dewormingsList = new List<DewormingModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_DEWORMING_GETALL", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dewormingsList.Add(new DewormingModel
                        {
                            dewormingId = Convert.ToInt32(dr["dewormingId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            applicationDate = Convert.ToDateTime(dr["applicationDate"])
                        });
                    }
                }

                return dewormingsList;
            }
        }

        /// <summary>
        /// Get specific record from deworming
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DewormingModel GetDewormingById(int dewormingId)
        {
            DewormingModel deworming = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_DEWORMING_GET_BY_ID", connection);
                cmd.Parameters.AddWithValue("@DewormingId", dewormingId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        deworming = new DewormingModel
                        {
                            dewormingId = Convert.ToInt32(dr["dewormingId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            applicationDate = Convert.ToDateTime(dr["applicationDate"])
                        };
                    }
                }

                return deworming;
            }
        }

        /// <summary>
        /// Record one record of deworming
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        public bool CreateDeworming(DewormingModel deworming)
        {
            var saveDeworming = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_DEWORMING_CREATE", connection);
                    cmd.Parameters.AddWithValue("@PetId", deworming.petId);
                    cmd.Parameters.AddWithValue("@ApplicationDate", deworming.applicationDate);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                saveDeworming = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveDeworming = false;
            }

            return saveDeworming;
        }

        /// <summary>
        /// Update one record from deworming
        /// </summary>
        /// <param name="deworming"></param>
        /// <returns></returns>
        public bool UpdateDeworming(DewormingModel deworming)
        {
            var saveDeworming = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_DEWORMING_UPDATE", connection);
                    cmd.Parameters.AddWithValue("@DewormingId", deworming.dewormingId);
                    cmd.Parameters.AddWithValue("@PetId", deworming.petId);
                    cmd.Parameters.AddWithValue("@ApplicationDate", deworming.applicationDate);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                saveDeworming = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveDeworming = false;
            }

            return saveDeworming;
        }

        /// <summary>
        /// Delete one record of deworming
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <returns></returns>
        public bool DeleteDeworming(int dewormingId)
        {
            var dewormingDelete = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_DEWORMING_DELETE", connection);
                    cmd.Parameters.AddWithValue("@DewormingId", dewormingId);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                dewormingDelete = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                dewormingDelete = false;
            }

            return dewormingDelete;
        }
    }
}