using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class ShowerModel
    {
        [Required]
        public int showerId {  get; set; }
        [Required]
        public int petId { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }

    }
}
