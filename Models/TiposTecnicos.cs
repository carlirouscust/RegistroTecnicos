﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class TiposTecnicos
{
    [Key]
    public int TiposTecnicosID { get; set; }
    
    [Required(ErrorMessage = "El campo es obligatorio")] 
    public string? Descripcion { get; set; }

    public ICollection<Tecnicos>? Tecnicos { get; set; } = new List<Tecnicos>();

}
