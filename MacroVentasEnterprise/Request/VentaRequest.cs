using MacroVentasEnterprise.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroVentasEnterprise.Request
{
    public class VentaRequest
    {
        public long IdVentas { get; set; }
        public long IdCliente { get; set; }


        public long UserId { get; set; }

     

        public virtual ICollection<VentaDetalleRequest>? VentaDetalles { get; set; }
    }


    public class MostrarVentaRequest
    {
        public long IdVentas { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal IVA { get; set; } = 13;
        public string Empleado { get; set; }
        public virtual ICollection<MostrarVentaDetalleRequest>? VentaDetalles { get; set; }
    }

}
