using MacroVentasEnterprise.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroVentasEnterprise.Request
{
    public class VentaDetalleRequest
    {
        public long IdVentaDetalle { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public long IdProducto { get; set; }
        public long IdVentas { get; set; }
    }


    public class MostrarVentaDetalleRequest
    {
        public long IdVentaDetalle { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public string NombreProducto { get; set; }
        public long IdVentas { get; set; }
    }
}

