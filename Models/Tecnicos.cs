using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        public int tecnicosID { get; set; }
        [Required(ErrorMessage = "El campo de Nombre es obligatorio")]

        public string? Nombre { get; set; }

        public int sueldoHora { get; set; }
    }
}
