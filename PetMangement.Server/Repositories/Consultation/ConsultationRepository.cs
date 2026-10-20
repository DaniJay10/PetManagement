using PetMangement.Server.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PetMangement.Server.Repositories.Consultation
{
    public class ConsultationRepository(IConfiguration configuration) : IConsultationRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("ConnectionString");

        /// <summary>
        /// Get all records from Consultation
        /// </summary>
        /// <returns></returns>
        public List<ConsultationModel> GetConsultations()
        {
            var consultationsList = new List<ConsultationModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_CONSULTATION_GETALL", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        consultationsList.Add(new ConsultationModel
                        {
                            consultationId = Convert.ToInt32(dr["consultationId"]),
                            petId = Convert.ToInt32(dr["petId"]),
                            reason = dr["reason"].ToString(),
                            diagnosis = dr["diagnosis"].ToString(),
                            notes = dr["notes"].ToString(),
                            consultationDate = Convert.ToDateTime(dr["consultationDate"]),
                        });
                    }
                }

                return consultationsList;
            }
        }

        /// <summary>
        /// Get specific record from consultation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ConsultationModel GetConsultation(int consultationId)
        {
            var consultation = new ConsultationModel();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("PM_CONSULTATION_GET_BY_ID", connection);
                cmd.Parameters.AddWithValue("@consultationId", consultationId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        consultation.consultationId = Convert.ToInt32(dr["consultationId"]);
                        consultation.petId = Convert.ToInt32(dr["petId"]);
                        consultation.reason = dr["reason"].ToString();
                        consultation.diagnosis = dr["diagnosis"].ToString();
                        consultation.notes = dr["notes"].ToString();
                        consultation.consultationDate = Convert.ToDateTime(dr["consultationDate"]);
                    }
                }

                return consultation;
            }
        }

        /// <summary>
        /// Record one consult
        /// </summary>
        /// <param name="Consultation"></param>
        /// <returns></returns>
        public bool InsertConsultation(ConsultationModel consultation)
        {
            var saveConsultation = false;

            try
            {

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_CONSULTATION_CREATE", connection);

                    cmd.Parameters.AddWithValue("@PetId", consultation.petId);
                    cmd.Parameters.AddWithValue("@Reason", consultation.reason);
                    cmd.Parameters.AddWithValue("@Diagnosis", consultation.diagnosis);
                    cmd.Parameters.AddWithValue("@Notes", consultation.notes);
                    cmd.Parameters.AddWithValue("@ConsultationDate", consultation.consultationDate);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                saveConsultation = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveConsultation = false;
            }

            return saveConsultation;
        }

        /// <summary>
        /// Update one record from consultation
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public bool UpdateConsultation(ConsultationModel consultation)
        {
            var saveConsultation = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_CONSULTATION_UPDATE", connection);

                    cmd.Parameters.AddWithValue("@ConsultationId", consultation.consultationId);
                    cmd.Parameters.AddWithValue("@PetId", consultation.petId);
                    cmd.Parameters.AddWithValue("@Reason", consultation.reason);
                    cmd.Parameters.AddWithValue("@Diagnosis", consultation.diagnosis);
                    cmd.Parameters.AddWithValue("@Notes", consultation.notes);
                    cmd.Parameters.AddWithValue("@ConsultationDate", consultation.consultationDate);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                saveConsultation = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                saveConsultation = false;
            }

            return saveConsultation;
        }

        /// <summary>
        /// Delete one record from consultation
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        public bool DeleteConsultation(int consultationId)
        {
            var ConsultationDelete = false;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("PM_CONSULTATION_DELETE", connection);
                    cmd.Parameters.AddWithValue("@ConsultationId", consultationId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                ConsultationDelete = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                ConsultationDelete = false;
            }

            return ConsultationDelete;
        }
    }
}
