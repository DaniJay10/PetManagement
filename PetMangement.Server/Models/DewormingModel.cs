using System.ComponentModel.DataAnnotations;

namespace PetMangement.Server.Models
{
    public class DewormingModel
    {
        [Required]
        private int dewormingId {get; set;}
        [Required]
        private int petId {get; set;}
        [Required]
        private DateTime applicationDate {get; set;}

    }
}
