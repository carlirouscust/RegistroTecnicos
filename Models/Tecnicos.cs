using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        public int tecnicosID { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]

        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int? sueldoHora { get; set; }
    }
}
