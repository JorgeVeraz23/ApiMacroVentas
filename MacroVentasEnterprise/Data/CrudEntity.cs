namespace MacroVentasEnterprise.Data
{
    public class CrudEntity
    {
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaEliminacion { get; set;  }
        public string? UsuarioCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public string? UsuarioEliminacion { get; set; }
    }
}
