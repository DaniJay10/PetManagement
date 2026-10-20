using PetMangement.Server.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PetMangement.Server.Repositories.Pet
{
    public class PetRepository(IConfiguration configuration) : IPetRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("ConnectionString");

        /// <summary>
        /// Get all records from pet
        /// </summary>
        /// <returns></returns>
        public List<PetModel> GetPets()
        {
            var petsList = new List<PetModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_PET_GETALL", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        petsList.Add(new PetModel
                        {
                            petId = Convert.ToInt32(dr["petId"]),
                            petName = dr["petName"].ToString(),
                            specie = dr["specie"].ToString(),
                            breed = dr["breed"].ToString(),
                            birthDate = Convert.ToDateTime(dr["birthDate"]),
                            petWeight = Convert.ToDecimal(dr["petWeight"]),
                            petSize = dr["petSize"].ToString(),
                            dewormingFrequency = Convert.ToInt32(dr["dewormingFrequency"])
                        });
                    }
                }

                return petsList;
            }

        }

        /// <summary>
        /// Get specific record from pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PetModel GetPet(int petId) 
        {
            var pet = new PetModel();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_PET_GET_BY_ID", connection);
                cmd.Parameters.AddWithValue("@PetId", petId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pet.petId = Convert.ToInt32(dr["petId"]);
                        pet.petName = dr["petName"].ToString();
                        pet.specie = dr["specie"].ToString();
                        pet.breed = dr["breed"].ToString();
                        pet.birthDate = Convert.ToDateTime(dr["birthDate"]);
                        pet.petWeight = Convert.ToDecimal(dr["petWeight"]);
                        pet.petSize = dr["petSize"].ToString();
                        pet.dewormingFrequency = Convert.ToInt32(dr["dewormingFrequency"]);
                    }
                }

                return pet;
            }
        }

        /// <summary>
        /// Record one pet
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        public bool InsertPet(PetModel Pet)
        {
            var savePet = false;

            try
            {

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_PET_CREATE", connection);

                    cmd.Parameters.AddWithValue("@PetName", Pet.petName);
                    cmd.Parameters.AddWithValue("@Specie", Pet.specie);
                    cmd.Parameters.AddWithValue("@Breed", Pet.breed);
                    cmd.Parameters.AddWithValue("@BirthDate", Pet.birthDate);
                    cmd.Parameters.AddWithValue("@PetWeight", Pet.petWeight);
                    cmd.Parameters.AddWithValue("@PetSize", Pet.petSize);
                    cmd.Parameters.AddWithValue("@DewormingFrequency", Pet.dewormingFrequency);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                savePet = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                savePet = false;
            }

            return savePet;
        }

        /// <summary>
        /// Update one record from pet
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        public bool UpdatePet(PetModel Pet)
        {
            var savePet = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_PET_UPDATE", connection);

                    cmd.Parameters.AddWithValue("@PetId", Pet.petId);
                    cmd.Parameters.AddWithValue("@PetName", Pet.petName);
                    cmd.Parameters.AddWithValue("@Specie", Pet.specie);
                    cmd.Parameters.AddWithValue("@Breed", Pet.breed);
                    cmd.Parameters.AddWithValue("@BirthDate", Pet.birthDate);
                    cmd.Parameters.AddWithValue("@PetWeight", Pet.petWeight);
                    cmd.Parameters.AddWithValue("@PetSize", Pet.petSize);
                    cmd.Parameters.AddWithValue("@DewormingFrequency", Pet.dewormingFrequency);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                savePet = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                savePet = false;
            }

            return savePet;
        }

        /// <summary>
        /// Delete one record from pet
        /// </summary>
        /// <param name="PetId"></param>
        /// <returns></returns>
        public bool DeletePet(int PetId)
        {
            var PetDelete = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_PET_DELETE", connection);
                    cmd.Parameters.AddWithValue("PetId", PetId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                PetDelete = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                PetDelete = false;
            }

            return PetDelete;
        }
    }
}
