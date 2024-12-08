using MacroVentasEnterprise.DTO;

namespace MacroVentasEnterprise.Interfaces
{
    public interface ClienteInterface
    {
        public Task<List<ClienteDTO>> GetAllCLientes();
        public Task<ClienteDTO> GetCliente(long id);
        public Task<List<ValueLabelDTO>> SelectorCliente();
        public Task<MessageInfoDTO> CrearCliente(ClienteDTO clienteDTO);
        public Task<MessageInfoDTO> EditarCliente(ClienteDTO clienteDTO);
        public Task<MessageInfoDTO> DeleteCliente(long id);
    }
}
