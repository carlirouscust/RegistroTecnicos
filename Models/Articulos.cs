using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Articulos
{
    [Key]
    public int articuloId { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? descripcion { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? costo { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? precio { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? existencia { get; set; }
}
