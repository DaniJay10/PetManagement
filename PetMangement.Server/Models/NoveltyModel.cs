using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class NoveltyModel
    {
        [Required]
        public int noveltyId {  get; set; }
        [Required]
        public int petId { get; set; }
        [Required]
        public DateTime noveltyDate { get; set; }
        [Required]
        public string description { get; set; }
    }
}
