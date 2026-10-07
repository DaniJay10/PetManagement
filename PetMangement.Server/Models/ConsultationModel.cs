using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class ConsultationModel
    {
        [Required]
        private int consultationId { get; set; }
        [Required]
        private int petId { get; set; }
        [Required]
        private DateTime consultationDate { get; set; }
        [Required]
        private string reason { get; set; }
        [Required]
        private string diagnosis { get; set; }
        [Required]
        private string notes { get; set; }
    }
}
