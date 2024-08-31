using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        public int tecnicosID { get; set; }
        [Required(ErrorMessage = "El campo de Descripcion es obligatorio")]

        public string? descripcion { get; set; }
    }
}
