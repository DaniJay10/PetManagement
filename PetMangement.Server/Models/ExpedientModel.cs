using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class ExpedientModel
    {
        [Required]
        public PetModel pet { get; set; }
        [Required]
        public List<ConsultationModel> consultations { get; set; }
        [Required]
        public List<DewormingModel> dewormings { get; set; }
        [Required]
        public List<NoveltyModel> novelties { get; set; }
        [Required]
        public List<ShowerModel> showers { get; set; }
        [Required]
        public List<VaccineModel> vaccines { get; set; }
    }
}
