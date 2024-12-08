using MacroVentasEnterprise.Data;
using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MacroVentasEnterprise.Repository
{
    public class ClienteRepository : ClienteInterface
    {
        private readonly ApplicationDbContext _context;

       
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public ClienteRepository(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _configuration = configuration;

            _ip = httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _username = Task.Run(async () =>
            (
                await userManager.FindByNameAsync(
                    httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""
                )
            )?.UserName ?? "Desconocido").Result;
        }


        public async Task<MessageInfoDTO> CrearCliente(ClienteDTO clienteDTO)
        {
            try
            {

                var clienteToCreate = await _context.Cliente.AsNoTracking().Where(x => x.Activo && x.Cedula.ToUpper().Equals(clienteDTO.Cedula.ToUpper())).FirstOrDefaultAsync();

                if (clienteToCreate != null)
                {
                    return infoDTO.AccionFallida("Ya existe un cliente registrado con la misma cedula", 400);
                }

                Cliente clienteEntity = new Cliente();

                clienteEntity.Activo = true;
                clienteEntity.NombreCliente = clienteDTO.NombreCliente;
                clienteEntity.Cedula = clienteDTO.Cedula;
                clienteEntity.Direccion = clienteDTO.Direccion;
                clienteEntity.Telefono = clienteDTO.Telefono;


                clienteEntity.UsuarioCreacion = _username;
                clienteEntity.FechaCreacion = DateTime.Now;

                await _context.Cliente.AddAsync(clienteEntity);
                await _context.SaveChangesAsync();

                return infoDTO.AccionCompletada("Se creo el cliente exitosamente!");
            }catch(Exception ex)
            {
                return infoDTO.ErrorInterno(ex, "Hubo un error interno al intentar crear", "500");
            }

        }

        public Task<MessageInfoDTO> DeleteCliente(long id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageInfoDTO> EditarCliente(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClienteDTO>> GetAllCLientes()
        {
            var clienteList = await _context.Cliente.AsNoTracking().Where(x => x.Activo).Select(c => new ClienteDTO
            {
                IdCliente = c.IdCliente,
                Cedula = c.Cedula,
                NombreCliente = c.NombreCliente,
                Telefono = c.Telefono,
                Direccion = c.Direccion,

            }).ToListAsync();

            return clienteList;
        }

        public async Task<ClienteDTO> GetCliente(long id)
        {
            var clienteRequest = await _context.Cliente.AsNoTracking().Where(x => x.Activo && x.IdCliente == id).Select(c => new ClienteDTO
            {
                IdCliente = c.IdCliente,
                Cedula = c.Cedula,
                NombreCliente = c.NombreCliente,
                Telefono = c.Telefono,
                Direccion = c.Direccion,

            }).FirstOrDefaultAsync() ?? throw new ArgumentException("No se encontro la informacion solicitada");

            return clienteRequest;
        }

        public Task<List<ValueLabelDTO>> SelectorCliente()
        {
            throw new NotImplementedException();
        }
    }
}
