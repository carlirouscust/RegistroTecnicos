using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicosID { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]

    public string? Nombre { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public int? SueldoHora { get; set; }
}