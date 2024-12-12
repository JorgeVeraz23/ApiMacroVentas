using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroVentasEnterprise.Data
{
    public class Producto : CrudEntity
    {
        [Key]
        public long IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CodigoProducto { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        [ForeignKey("CategoriaProducto")]
        public long IdCategoria { get; set; }
        public ICollection<VentaDetalle>? VentaDetalles { get; set; }
        public virtual CategoriaProducto? CategoriaProducto { get; set; }
    }
}
