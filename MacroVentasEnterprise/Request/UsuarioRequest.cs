namespace MacroVentasEnterprise.Request
{
    public class UsuarioRequest
    {
        public long IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string? Telefono { get; set; }
        public string? Identitificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }    

    }
}
