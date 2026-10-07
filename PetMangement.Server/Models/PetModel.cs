using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class PetModel
    {
        [Required]
        private int petId { get; set; }
        [Required]
        private string petName { get; set; }
        [Required]
        private string specie { get; set; }
        [Required]
        private string breed { get; set; }
        [Required]
        private DateTime birthDate { get; set; }
        [Required]
        private float petWeight { get; set; }
        [Required]
        private string petSize { get; set; }
        [Required]
        private int deworingFrequency { get; set; }
    }
}
