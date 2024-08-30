using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Prioridades
    {
        [Key]
        public int prioridadID { get; set; }
        [Required(ErrorMessage = "El campo de Descripcion es obligatorio")]

        public string? descripcion { get; set; }
    }
}
