using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Response;

namespace MacroVentasEnterprise.Interfaces
{
    public interface ClienteInterface
    {
        public Task<List<ClienteRequest>> GetAllCLientes();
        public Task<ClienteRequest> GetCliente(long id);
        public Task<List<ValueLabelRequest>> SelectorCliente();
        public Task<ApiReponse> CrearCliente(ClienteRequest clienteDTO);
        public Task<ApiReponse> EditarCliente(ClienteRequest clienteDTO);
        public Task<ApiReponse> DeleteCliente(long id);
    }
}
