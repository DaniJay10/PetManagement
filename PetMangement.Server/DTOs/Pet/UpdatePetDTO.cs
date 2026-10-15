namespace PetMangement.Server.DTOs.Pet
{
    public class UpdatePetDTO
    {
        public int petId { get; set; }
        public string petName { get; set; }
        public string specie { get; set; }
        public string breed { get; set; }
        public DateTime birthDate { get; set; }
        public decimal petWeight { get; set; }
        public string petSize { get; set; }
        public int dewormingFrequency { get; set; }
    }
}
