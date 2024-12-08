namespace MacroVentasEnterprise.DTO
{
    public class ApplicationUserDTO
    {
        public string Correo { get; set; }
        public string Password { get; set; }
        public string? Telefono { get; set; }
        public string? Identitificacion { get; set; }
    }

    public class LoginUserDTO
    {
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
