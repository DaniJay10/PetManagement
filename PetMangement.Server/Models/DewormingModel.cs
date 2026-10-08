using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class DewormingModel
    {
        [Required]
        public int dewormingId {get; set;}
        [Required]
        public int petId {get; set;}
        [Required]
        public DateTime applicationDate {get; set;}

    }
}
