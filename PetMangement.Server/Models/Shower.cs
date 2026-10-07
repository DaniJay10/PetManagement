using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class Shower
    {
        [Required]
        private int showerId {  get; set; }
        [Required]
        private int petId { get; set; }
        [Required]
        private DateTime ApplicationDate { get; set; }

    }
}
