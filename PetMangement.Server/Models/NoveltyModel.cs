using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class NoveltyModel
    {
        [Required]
        private int noveltyId {  get; set; }
        [Required]
        private int petId { get; set; }
        [Required]
        private DateTime noveltyDate { get; set; }
        [Required]
        private string descripcion { get; set; }
    }
}
