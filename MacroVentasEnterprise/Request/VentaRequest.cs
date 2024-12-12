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


    public class ReporteVentasRequest
    {
        public long idVentas { get; set; }
        public DateTime fechaCreacion { get; set; }
        public decimal totalVenta { get; set; }
        public decimal iva { get; set; }
        public virtual ICollection<DetalleReporteVentasRequest>? detalles { get; set; }
        public virtual ICollection<ProductosEnStockRequest>? productoEnStock { get; set; }  
        
    }


    public class DetalleReporteVentasRequest
    {
        public long idProducto { get; set; }
        public string producto { get; set; }
        public decimal cantidad { get; set; }    
        public decimal subTotal { get; set; }
    }

    public class ProductosEnStockRequest
    {
        public long idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }
        public bool bajoStock { get; set; }

    }
}
