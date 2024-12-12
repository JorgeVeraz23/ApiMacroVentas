using MacroVentasEnterprise.Data;

namespace MacroVentasEnterprise.Request
{
    public class ProductoRequest
    {
        public long IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CodigoProducto { get; set; }
        public int Stock { get; set; }

        public decimal Precio { get; set; }
        public long idCategoriaProducto { get; set; }

    }
}
