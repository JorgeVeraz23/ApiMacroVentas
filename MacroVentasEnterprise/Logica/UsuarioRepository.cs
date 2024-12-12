using MacroVentasEnterprise.Data;
using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Request;
using MacroVentasEnterprise.Response;
using Microsoft.EntityFrameworkCore;

namespace MacroVentasEnterprise.Logica
{
    public class UsuarioRepository : UsuarioInterface
    {

        private readonly ApplicationDbContext _context;
        private ApiReponse infoReponse = new ApiReponse();

        public UsuarioRepository(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task<ApiReponse> CreateUsuario(UsuarioRequest usuario)
        {
            try
            {
                var usuarioToCreate = await _context.User.Where(x => x.Activo && x.Correo.ToUpper().Equals(usuario.Correo.ToUpper())).FirstOrDefaultAsync();

                if (usuarioToCreate != null)
                {
                    return infoReponse.AccionFallida("Ya existe un usuario creado con ese nombre", 400);
                }



                Usuario usuarioEntity = new Usuario();

                usuarioEntity.Activo = true;


                usuarioEntity.Correo = usuario.Correo;
                usuarioEntity.Contrasenia = usuario.Contrasenia;
                usuarioEntity.Telefono = usuario.Telefono;
                usuarioEntity.Identitificacion = usuario.Identitificacion;
                usuarioEntity.Nombre = usuario.Nombre;
                usuarioEntity.Apellido = usuario.Apellido;

                usuarioEntity.FechaCreacion = DateTime.Now;

                await _context.User.AddAsync(usuarioEntity);
                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se creo el usuario exitosamente");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "UsuarioController", "Hubo un error interno al intentar crear el usuario");
            }


        }

        public async Task<ApiReponse> EditarUsuario(UsuarioRequest usuario)
        {
            try
            {
                var model = await _context.User.Where(x => x.Activo && x.IdUsuario == usuario.IdUsuario).FirstOrDefaultAsync();

            if(model == null)
            {
                return infoReponse.AccionFallida("No se encontro el usuario que se intenta editar", 404);
            }

            model.Correo = usuario.Correo;
            model.Contrasenia = usuario.Contrasenia;
            model.Telefono = usuario.Telefono;
            model.Identitificacion = usuario.Identitificacion;
                    
            model.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();

            return infoReponse.AccionCompletada("Se edito el usuario exitosamente");

        }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "UsuarioController", "Hubo un error interno al intentar editar el usuario");
            }


}

        public async Task<ApiReponse> EliminarUsuario(long id)
        {
            try
            {
                var usuarioToDelete = await _context.User.Where(x => x.Activo && x.IdUsuario == id).FirstOrDefaultAsync();

                if(usuarioToDelete == null)
                {
                    return infoReponse.AccionFallida("No se encontro el usuario que se intenta eliminar", 404);
                }

                usuarioToDelete.Activo = false;

                usuarioToDelete.FechaEliminacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se elimino el usuario exitosamente");

            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "UsuarioController", "Hubo un error interno al intentar eliminar el usuario");
            }
        }

        public async Task<List<UsuarioRequest>> GetAllUsuarios()
        {
            var usuariosList = await _context.User.AsNoTracking().Where(x => x.Activo).Select(c => new UsuarioRequest
            {
                IdUsuario = c.IdUsuario,
                Correo = c.Correo,
                Contrasenia = c.Contrasenia,
                Identitificacion = c.Identitificacion,
                Telefono = c.Telefono,
            }).ToListAsync();

            return usuariosList;
        }

        public async Task<UsuarioRequest> GetUsuarioById(long id)
        {
            var usuarioRequest = await _context.User.AsNoTracking().Where(x => x.Activo && x.IdUsuario == id).Select(c => new UsuarioRequest
            {
                IdUsuario = c.IdUsuario,
                Correo = c.Correo,
                Contrasenia = c.Contrasenia,
                Identitificacion = c.Identitificacion,
                Telefono= c.Telefono,   
            }).FirstOrDefaultAsync() ?? throw new ArgumentNullException("No se encontro el usuario solicitado");

            
            return usuarioRequest;

        }

        public async Task<ApiReponse> LoginUsuario(string correo, string contrasenia)
        {
            var validacionLogin = await _context.User.Where(x => x.Activo && x.Correo.ToUpper().Equals(correo.ToUpper()) && x.Contrasenia.ToUpper().Equals(contrasenia.ToUpper())).FirstOrDefaultAsync();

            if(validacionLogin == null)
            {
                return infoReponse.AccionFallida("No existe el usuario que se intenta loguear", 400);
            }

            return infoReponse.AccionCompletadaLoginUsuario("El inicio de sesión fue exitoso!", validacionLogin.Correo, validacionLogin.IdUsuario);

        }

        public async Task<List<ValueLabelRequest>> SelectorUsuarios()
        {
            var usuarioSelector = await _context.User.AsNoTracking().Where(x => x.Activo).Select(c => new ValueLabelRequest
            {
                Value = c.IdUsuario.ToString(),
                Label = c.Correo,
            }).ToListAsync();

            return usuarioSelector;
        }
    }
}
