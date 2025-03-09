using System.ComponentModel.DataAnnotations;

namespace REST_API_CV_Hantering.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        [StringLength(100, ErrorMessage = "Namn får inte vara längre än 100 tecken.")]
        public string Namn { get; set; }

        [StringLength(500, ErrorMessage = "Beskrivning får inte vara längre än 500 tecken.")]
        public string Beskrivning { get; set; }

        [StringLength(250, ErrorMessage = "Kontaktuppgifter får inte vara längre än 250 tecken.")]
        public string Kontaktuppgifter { get; set; }

        public List<Utbildning> Utbildningar { get; set; } = [];
        public List<Arbetserfarenhet> Arbetserfarenheter { get; set; } = [];
    }
}
