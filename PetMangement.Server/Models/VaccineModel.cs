using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class VaccineModel
    {
        [Required]
        private int vaccineId { get; set; }
        [Required]
        private int petId { get; set; }
        [Required]
        private string vaccineType { get; set; }
        [Required]
        private DateTime applicationDate { get; set; }
    }
}
