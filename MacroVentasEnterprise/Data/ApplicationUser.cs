using Microsoft.AspNetCore.Identity;

namespace MacroVentasEnterprise.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string? Telefono { get; set; }
        public string? Identitificacion { get; set; }
       
    }
}
