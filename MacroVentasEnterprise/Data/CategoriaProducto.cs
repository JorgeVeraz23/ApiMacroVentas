using System.ComponentModel.DataAnnotations;

namespace MacroVentasEnterprise.Data
{
    public class CategoriaProducto : CrudEntity
    {
        [Key]
        public long IdCategoriaProducto { get; set; }   
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
