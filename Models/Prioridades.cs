﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RegistroTecnicos.Models;

public class Prioridades
{
    [Key]
    public int PrioridadesID { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public int? Tiempo { get; set; }
    public ICollection<Trabajos>? Trabajos { get; set; } = new List<Trabajos>();

}
