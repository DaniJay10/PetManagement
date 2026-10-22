namespace PetMangement.Server.DTOs.Novelty
{
    public class UpdateNoveltyDTO
    {
        public int noveltyId { get; set; }
        public int petId { get; set; }
        public DateTime noveltyDate { get; set; }
        public string description { get; set; }
    }
}