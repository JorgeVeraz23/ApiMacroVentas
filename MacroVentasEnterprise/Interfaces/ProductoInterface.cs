using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Request;
using MacroVentasEnterprise.Response;

namespace MacroVentasEnterprise.Interfaces
{
    public interface ProductoInterface
    {
        public Task<ApiReponse> CrearProducto(ProductoRequest productoRequest);
        public Task<ApiReponse> EditarProducto(ProductoRequest productoRequest);
        public Task<ApiReponse> DeleteProducto(long id);
        public Task<List<MostrarProductoRequest>> GetAllProducto();
        public Task<ProductoRequest> GetProductoById(long id);
        public Task<List<ValueLabelRequest>> SelectorProducto();


    }
}
