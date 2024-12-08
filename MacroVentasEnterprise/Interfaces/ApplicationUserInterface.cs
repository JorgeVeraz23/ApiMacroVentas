using MacroVentasEnterprise.DTO;

namespace MacroVentasEnterprise.Interfaces
{
    public interface ApplicationUserInterface
    {
        public Task<List<ApplicationUserDTO>> GetAllApplicationUser();
        public Task<ApplicationUserDTO> GetApplicationUser(string id);
        public Task<List<ValueLabelDTO>> SelectorUsuarios();
        public Task<MessageInfoDTO> CrearUsuario(ApplicationUserDTO applicationUserDTO);
        public Task<MessageInfoDTO> EditarUsuario(ApplicationUserDTO applicatioUserDTO);
        public Task<MessageInfoDTO> EliminarUsuario(long id);
    }
}
