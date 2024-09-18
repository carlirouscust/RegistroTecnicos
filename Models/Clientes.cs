using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RegistroTecnicos.Models;

public class Clientes
{
    [Key]
    public int ClientesID { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? WhatsApp { get; set; }

}
