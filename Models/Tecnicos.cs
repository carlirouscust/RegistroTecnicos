﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicosID { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]

    public string? Nombre { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public int? SueldoHora { get; set; }

    public TiposTecnicos? tiposTecnicos { get; set; }

    [ForeignKey("tiposTecnicos")]
    public int TiposTecnicosID { get; set; }

}