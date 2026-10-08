using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class ConsultationModel
    {
        [Required]
        public int consultationId { get; set; }
        [Required]
        public int petId { get; set; }
        [Required]
        public DateTime consultationDate { get; set; }
        [Required]
        public string reason { get; set; }
        [Required]
        public string diagnosis { get; set; }
        [Required]
        public string notes { get; set; }
    }
}
