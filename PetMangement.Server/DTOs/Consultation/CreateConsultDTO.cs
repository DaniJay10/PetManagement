namespace PetMangement.Server.DTOs.Consultation
{
    public class CreateConsultDTO
    {
        public int petId { get; set; }
        public DateTime consultationDate { get; set; }
        public string reason { get; set; }
        public string diagnosis { get; set; }
        public string notes { get; set; }
    }
}
