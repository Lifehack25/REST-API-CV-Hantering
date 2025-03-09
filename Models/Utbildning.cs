using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace REST_API_CV_Hantering.Models
{
    public class Utbildning
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Skola är obligatoriskt.")]
        [StringLength(150, ErrorMessage = "Skola får inte vara längre än 150 tecken.")]
        public string Skola { get; set; }

        [Required(ErrorMessage = "Examen är obligatoriskt.")]
        [StringLength(100, ErrorMessage = "Examen får inte vara längre än 100 tecken.")]
        public string Examen { get; set; }

        [Required(ErrorMessage = "Startdatum är obligatoriskt.")]
        public DateTime StartDatum { get; set; }

        [Required(ErrorMessage = "Slutdatum är obligatoriskt.")]
        public DateTime SlutDatum { get; set; }

        // Foreign key
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
