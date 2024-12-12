using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Request;
using MacroVentasEnterprise.Response;

namespace MacroVentasEnterprise.Interfaces
{
    public interface VentaInterface
    {
        public Task<ApiReponse> CrearVenta(VentaRequest ventaRequest);

        public Task<ApiReponse> EditarVenta(VentaRequest ventaRequest);

        public Task<ApiReponse> EliminarVenta(long id);

        public Task<List<MostrarVentaRequest>> GetAllVentas();
        public Task<MostrarVentaRequest> GetVentaById(long id);
        public Task<List<ValueLabelRequest>> SelectorVenta();
    }
}
