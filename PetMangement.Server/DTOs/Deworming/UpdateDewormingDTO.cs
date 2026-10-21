namespace PetMangement.Server.DTOs.Deworming
{
    public class UpdateDewormingDTO
    {
        public int dewormingId { get; set; }
        public int petId { get; set; }
        public DateTime applicationDate { get; set; }
    }
}
