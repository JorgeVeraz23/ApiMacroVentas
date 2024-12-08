using System.ComponentModel.DataAnnotations;

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
        public bool EsGravadoConIVA { get; set; }
        public decimal? TasaIVA { get; set; }

        public ICollection<VentaDetalle>? VentaDetalles { get; set; }
    }
}
