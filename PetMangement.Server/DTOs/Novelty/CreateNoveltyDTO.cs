namespace PetMangement.Server.DTOs.Novelty
{
    public class CreateNoveltyDTO
    {
        public int petId { get; set; }
        public DateTime noveltyDate { get; set; }
        public string description { get; set; }
    }
}