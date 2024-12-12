using MacroVentasEnterprise.Data;

namespace MacroVentasEnterprise.Request
{
    public class CategoriaProductoRequest
    {
        public long IdCategoriaProducto { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<ProductoRequest>? Productos { get; set; }
    }

    public class CrearCategoriaProductoRequest
    {
        public long IdCategoriaProducto { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
