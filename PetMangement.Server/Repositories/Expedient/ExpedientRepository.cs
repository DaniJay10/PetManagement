
using Microsoft.Data.SqlClient;
using PetMangement.Server.Data;
using PetMangement.Server.Models;
using System.Data;

namespace PetMangement.Server.Repositories.Expedient
{
    public class ExpedientRepository(IConfiguration configuration) : IExpedientRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("ConnectionString");

        /// <summary>
        /// Get all expedient of one record from Pet
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public ExpedientModel GetExpedientByPetId(int petId)
        {
            var expedient = new ExpedientModel
            {
                consultations = new List<ConsultationModel>(),
                dewormings = new List<DewormingModel>(),
                novelties = new List<NoveltyModel>(),
                showers = new List<ShowerModel>(),
                vaccines = new List<VaccineModel>()
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Data of Pet
                SqlCommand cmdPet = new SqlCommand("PM_PET_GET_BY_ID", connection);
                cmdPet.Parameters.AddWithValue("@PetId", petId);
                cmdPet.CommandType = CommandType.StoredProcedure;

                using (var dr = cmdPet.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        expedient.pet = new PetModel
                        {
                            petId = Convert.ToInt32(dr["petId"]),
                            petName = dr["petName"].ToString(),
                            specie = dr["specie"].ToString(),
                            breed = dr["breed"].ToString(),
                            birthDate = Convert.ToDateTime(dr["birthDate"]),
                            petWeight = Convert.ToDecimal(dr["petWeight"]),
                            petSize = dr["petSize"].ToString(),
                            dewormingFrequency = Convert.ToInt32(dr["dewormingFrequency"])
                        };
                    }
                }

                // Data of Consultation
                SqlCommand cmdConsultation = new SqlCommand("PM_CONSULTATION_GET_BY_PET_ID", connection);
                cmdConsultation.Parameters.AddWithValue("@PetId", petId);
                cmdConsultation.CommandType = CommandType.StoredProcedure;

                using (var dr = cmdConsultation.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        expedient.consultations.Add(new ConsultationModel
                        {
                            consultationId = Convert.ToInt32(dr["consultationId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            reason = dr["reason"].ToString(),
                            diagnosis = dr["diagnosis"].ToString(),
                            notes = dr["notes"].ToString(),
                            consultationDate = Convert.ToDateTime(dr["consultationDate"])
                        });
                    }
                }

                //Data of Deworming
                SqlCommand cmdDeworming = new SqlCommand("PM_DEWORMING_GET_BY_PET_ID", connection);
                cmdDeworming.Parameters.AddWithValue("@PetId", petId);
                cmdDeworming.CommandType = CommandType.StoredProcedure;

                using (var dr = cmdDeworming.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        expedient.dewormings.Add(new DewormingModel
                        {
                            dewormingId = Convert.ToInt32(dr["dewormingId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            applicationDate = Convert.ToDateTime(dr["applicationDate"])
                        });
                    }
                }

                //Data of Novelty
                SqlCommand cmdNovelty = new SqlCommand("PM_NOVELTY_GET_BY_PET_ID", connection);
                cmdNovelty.Parameters.AddWithValue("@PetId", petId);
                cmdNovelty.CommandType = CommandType.StoredProcedure;

                using (var dr = cmdNovelty.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        expedient.novelties.Add(new NoveltyModel
                        {
                            noveltyId = Convert.ToInt32(dr["noveltyId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            noveltyDate = Convert.ToDateTime(dr["noveltyDate"]),
                            description = Convert.ToString(dr["description"])
                        });
                    }
                }

                //Data of showers
                SqlCommand cmdShower = new SqlCommand("PM_SHOWER_GET_BY_PET_ID", connection);
                cmdShower.Parameters.AddWithValue("@PetId", petId);
                cmdShower.CommandType = CommandType.StoredProcedure;

                using (var dr = cmdShower.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        expedient.showers.Add(new ShowerModel
                        {
                            showerId = Convert.ToInt32(dr["showerId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"])
                        });
                    }
                }

                //Data of Vaccines
                SqlCommand cmdVaccine = new SqlCommand("PM_VACCINE_GET_BY_PET_ID", connection);
                cmdVaccine.Parameters.AddWithValue("@PetId", petId);
                cmdVaccine.CommandType = CommandType.StoredProcedure;

                using (var dr = cmdVaccine.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        expedient.vaccines.Add(new VaccineModel
                        {
                            vaccineId = Convert.ToInt32(dr["vaccineId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            vaccineType = dr["vaccineType"].ToString(),
                            applicationDate = Convert.ToDateTime(dr["applicationDate"]),
                        });
                    }
                }
            }
            return expedient;
        }
    }
}
