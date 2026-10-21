namespace PetMangement.Server.DTOs.Shower
{
    public class UpdateShowerDTO
    {
        public int showerId { get; set; }
        public int petId { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
