using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RegistroTecnicos.Models;

public class Trabajos
{
    [Key]
    public int TrabajosID { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public int? Monto { get; set; }

    public Tecnicos? tecnicos { get; set; }

    [ForeignKey("tecnicos")]
    public int TecnicosID { get; set; }

    public Clientes? clientes { get; set; }

    [ForeignKey("clientes")]
    public int ClientesID { get; set; }

}