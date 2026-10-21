namespace PetMangement.Server.DTOs.Vaccine
{
    public class CreateVaccineDTO
    {
        public int petId { get; set; }
        public string vaccineType { get; set; }
        public DateTime applicationDate { get; set; }
    }
}
