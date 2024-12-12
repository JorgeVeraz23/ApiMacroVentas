using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroVentasEnterprise.Data
{
    public class VentaDetalle : CrudEntity
    {
        [Key]
        public long IdVentaDetalle { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        

        [ForeignKey("Ventas")]
        public long IdVentas { get; set; }
        [ForeignKey("Producto")]
        public long IdProducto { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Ventas Ventas { get; set; }
    }
}
