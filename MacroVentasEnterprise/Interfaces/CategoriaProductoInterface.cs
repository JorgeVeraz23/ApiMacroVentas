using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Request;
using MacroVentasEnterprise.Response;

namespace MacroVentasEnterprise.Interfaces
{
    public interface CategoriaProductoInterface
    {
        public Task<List<CategoriaProductoRequest>> GetAllProducto();
        public Task<CategoriaProductoRequest> GetCategoriaProductoById(long id);
        public Task<List<ValueLabelRequest>> SelectorCategoriaProducto();
        public Task<ApiReponse> CrearCategoria(CrearCategoriaProductoRequest categoriaProductoResponse);
        public Task<ApiReponse> EditarCategoria(CrearCategoriaProductoRequest categoriaProductoResponse);
        public Task<ApiReponse> EliminarCategoria(long id);


    }
}
