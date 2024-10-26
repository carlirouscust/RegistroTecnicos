using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Cotizaciones
{
    [Key]
    public int cotizacionesId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    public Clientes? clientes { get; set; }

    [ForeignKey("clientes")]
    public int ClientesID { get; set; }


    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? observacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public int? monto { get; set; }

    public ICollection<CotizacionesDetalles> CotizacionesDetalles { get; set; }
}
