using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class TrabajosDetalles
{
    [Key]
    public int detalleId { get; set; }

    public Trabajos? Trabajos { get; set; }

    [ForeignKey("trabajoId")]
   
    public int trabajoId { get; set; }
    
    public Articulos? Articulos { get; set; }

    [ForeignKey("articuloId")]
    public int articuloId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public int cantidad { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? precio { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? costo { get; set; }
}
