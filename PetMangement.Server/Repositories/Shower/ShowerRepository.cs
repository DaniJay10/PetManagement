using PetMangement.Server.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PetMangement.Server.Repositories.Shower
{
    public class ShowerRepository(IConfiguration configuration) : IShowerRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("ConnectionString");

        /// <summary>
        /// Get all records from shower
        /// </summary>
        /// <returns></returns>
        public List<ShowerModel> GetShowers()
        {
            var showersList = new List<ShowerModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_SHOWER_GETALL", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        showersList.Add(new ShowerModel
                        {
                            showerId = Convert.ToInt32(dr["showerId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"])
                        });
                    }
                }

                return showersList;
            }
        }

        /// <summary>
        /// Get a specific record from shower
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        public ShowerModel GetShowerById(int showerId)
        {
            var shower = new ShowerModel();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_SHOWER_GET_BY_ID", connection);
                cmd.Parameters.AddWithValue("@ShowerId", showerId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        shower.showerId = Convert.ToInt32(dr["showerId"]);
                        shower.petId = Convert.ToInt32(dr["petId"]);
                        shower.ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]);
                    }
                }

                return shower;
            }
        }

        /// <summary>
        /// Create one shower record
        /// </summary>
        /// <param name="Shower"></param>
        /// <returns></returns>
        public bool CreateShower(ShowerModel Shower)
        {
            var saveShower = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_SHOWER_CREATE", connection);

                    cmd.Parameters.AddWithValue("@PetId", Shower.petId);
                    cmd.Parameters.AddWithValue("@ApplicationDate", Shower.ApplicationDate);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                saveShower = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveShower = false;
            }

            return saveShower;
        }

        /// <summary>
        /// Update one shower record
        /// </summary>
        /// <param name="Shower"></param>
        /// <returns></returns>
        public bool UpdateShower(ShowerModel Shower)
        {
            var saveShower = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_SHOWER_UPDATE", connection);

                    cmd.Parameters.AddWithValue("@ShowerId", Shower.showerId);
                    cmd.Parameters.AddWithValue("@PetId", Shower.petId);
                    cmd.Parameters.AddWithValue("@ApplicationDate", Shower.ApplicationDate);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                saveShower = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveShower = false;
            }

            return saveShower;
        }

        /// <summary>
        /// Delete one shower record
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        public bool DeleteShower(int showerId)
        {
            var showerDelete = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_SHOWER_DELETE", connection);
                    cmd.Parameters.AddWithValue("@ShowerId", showerId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                showerDelete = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                showerDelete = false;
            }

            return showerDelete;
        }
    }
}