using System.ComponentModel.DataAnnotations;

namespace MacroVentasEnterprise.Data
{
    public class Cliente : CrudEntity
    {
        [Key]
        public long IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Ventas>? Ventas { get; set; }

    }
}
