using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroVentasEnterprise.Data
{
    public class Ventas : CrudEntity
    {
        [Key]
        public long IdVentas { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal IVA { get; set; }


        [ForeignKey("User")]
        public long UserId { get; set; }


      
        public virtual Usuario User { get; set; }
        public virtual ICollection<VentaDetalle>? VentaDetalles { get; set; }
    }
}
