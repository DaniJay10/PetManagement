using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class VaccineModel
    {
        [Required]
        public int vaccineId { get; set; }
        [Required]
        public int petId { get; set; }
        [Required]
        public string vaccineType { get; set; }
        [Required]
        public DateTime applicationDate { get; set; }
    }
}
