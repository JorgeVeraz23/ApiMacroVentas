﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MacroVentasEnterprise.Data
{
    public class Usuario : CrudEntity
    { 
        [Key]
        public long IdUsuario { get; set; }    
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string? Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Identitificacion { get; set; }

        public virtual ICollection<Ventas>? VentasDeUsuario { get; set; }

    }
}
