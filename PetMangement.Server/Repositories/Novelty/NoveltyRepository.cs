using PetMangement.Server.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PetMangement.Server.Repositories.Novelty
{
    public class NoveltyRepository(IConfiguration configuration) : INoveltyRepository
    {
        private readonly string _connectionString =
            configuration.GetConnectionString("ConnectionString");

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        public List<NoveltyModel> GetNovelties()
        {
            var noveltiesList = new List<NoveltyModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_NOVELTY_GETALL", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        noveltiesList.Add(new NoveltyModel
                        {
                            noveltyId = Convert.ToInt32(dr["noveltyId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            noveltyDate = Convert.ToDateTime(dr["noveltyDate"]),
                            description = Convert.ToString(dr["description"])
                        });
                    }
                }

                return noveltiesList;
            }
        }

        /// <summary>
        /// Get a specific record from the DB
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <returns></returns>
        public NoveltyModel GetNoveltyById(int noveltyId)
        {
            NoveltyModel novelty = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_NOVELTY_GET_BY_ID", connection);
                cmd.Parameters.AddWithValue("@NoveltyId", noveltyId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        novelty = new NoveltyModel
                        {
                            noveltyId = Convert.ToInt32(dr["noveltyId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            noveltyDate = Convert.ToDateTime(dr["noveltyDate"]),
                            description = Convert.ToString(dr["description"])
                        };
                    }
                }

                return novelty;
            }
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="novelty"></param>
        /// <returns></returns>
        public bool CreateNovelty(NoveltyModel novelty)
        {
            var saveNovelty = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_NOVELTY_CREATE", connection);
                    cmd.Parameters.AddWithValue("@PetId", novelty.petId);
                    cmd.Parameters.AddWithValue("@NoveltyDate", novelty.noveltyDate);
                    cmd.Parameters.AddWithValue("@Description", novelty.description);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                saveNovelty = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveNovelty = false;
            }

            return saveNovelty;
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="novelty"></param>
        /// <returns></returns>
        public bool UpdateNovelty(NoveltyModel novelty)
        {
            var saveNovelty = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_NOVELTY_UPDATE", connection);
                    cmd.Parameters.AddWithValue("@NoveltyId", novelty.noveltyId);
                    cmd.Parameters.AddWithValue("@PetId", novelty.petId);
                    cmd.Parameters.AddWithValue("@NoveltyDate", novelty.noveltyDate);
                    cmd.Parameters.AddWithValue("@Description", novelty.description);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                saveNovelty = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveNovelty = false;
            }

            return saveNovelty;
        }

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <returns></returns>
        public bool DeleteNovelty(int noveltyId)
        {
            var noveltyDelete = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_NOVELTY_DELETE", connection);
                    cmd.Parameters.AddWithValue("@NoveltyId", noveltyId);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                noveltyDelete = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                noveltyDelete = false;
            }

            return noveltyDelete;
        }
    }
}