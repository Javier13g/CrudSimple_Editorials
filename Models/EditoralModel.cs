using System.ComponentModel.DataAnnotations;

namespace CrudSimple_Editorials.Models
{
    public class EditoralModel
    {
        [Required]
        public int CodEditorial { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Limite alcanzado")]
        public string NombreEditorial { get; set; } = null!;

        [Required]
        public decimal LatitudUbicacion { get; set; }
        public decimal LongitudUbicacion { get; set; }
    }
}
