using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_CV_Hantering.Models
{
    public class Arbetserfarenhet
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Jobbtitel är obligatoriskt.")]
        [StringLength(100, ErrorMessage = "Jobbtitel får inte vara längre än 100 tecken.")]
        public string Jobbtitel { get; set; }

        [Required(ErrorMessage = "Företag är obligatoriskt.")]
        [StringLength(150, ErrorMessage = "Företag får inte vara längre än 150 tecken.")]
        public string Företag { get; set; }

        [StringLength(500, ErrorMessage = "Beskrivning får inte vara längre än 500 tecken.")]
        public string Beskrivning { get; set; }

        [Required(ErrorMessage = "Arbetsår är obligatoriskt.")]
        public int Arbetsår { get; set; }

        // Foreign key
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
