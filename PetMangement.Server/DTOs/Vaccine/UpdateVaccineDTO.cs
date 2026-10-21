namespace PetMangement.Server.DTOs.Vaccine
{
    public class UpdateVaccineDTO
    {
        public int vaccineId { get; set; }
        public int petId { get; set; }
        public string vaccineType { get; set; }
        public DateTime applicationDate { get; set; }
    }
}
