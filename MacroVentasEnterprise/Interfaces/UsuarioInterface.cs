using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Request;
using MacroVentasEnterprise.Response;

namespace MacroVentasEnterprise.Interfaces
{
    public interface UsuarioInterface
    {
        public Task<List<UsuarioRequest>> GetAllUsuarios();
        public Task<UsuarioRequest> GetUsuarioById(long id);
        public Task<List<ValueLabelRequest>> SelectorUsuarios();
        public Task<ApiReponse> LoginUsuario(string correo, string contrasenia);
        public Task<ApiReponse> CreateUsuario(UsuarioRequest usuario);
        public Task<ApiReponse> EditarUsuario(UsuarioRequest usuario);
        public Task<ApiReponse> EliminarUsuario(long id);

    }
}
