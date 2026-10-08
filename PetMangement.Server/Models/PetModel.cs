using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class PetModel
    {
        [Required]
        public int petId { get; set; }
        [Required]
        public string petName { get; set; }
        [Required]
        public string specie { get; set; }
        [Required]
        public string breed { get; set; }
        [Required]
        public DateTime birthDate { get; set; }
        [Required]
        public decimal petWeight { get; set; }
        [Required]
        public string petSize { get; set; }
        [Required]
        public int deworingFrequency { get; set; }
    }
}
