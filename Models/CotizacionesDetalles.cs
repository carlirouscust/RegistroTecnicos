using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class CotizacionesDetalles
{
    [Key]
   
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]

    public Cotizaciones? cotizaciones { get; set; }

    [ForeignKey("cotizaciones")]
    public int CotizacionId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? Precio { get; set; }

    public Articulos? Articulos { get; set; }
    [ForeignKey("Articulos")]
    public int ArticuloId { get; set; }
}
