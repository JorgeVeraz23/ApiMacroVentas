using MacroVentasEnterprise.Data;
using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MacroVentasEnterprise.Repository
{
    public class ClienteRepository : ClienteInterface
    {
        private readonly ApplicationDbContext _context;

        private ApiReponse infoReponse = new ApiReponse();


        public ClienteRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }


        public async Task<ApiReponse> CrearCliente(ClienteRequest clienteRequest)
        {
            try
            {

                var clienteToCreate = await _context.Cliente.AsNoTracking().Where(x => x.Activo && x.Cedula.ToUpper().Equals(clienteRequest.Cedula.ToUpper())).FirstOrDefaultAsync();

                if (clienteToCreate != null)
                {
                    return infoReponse.AccionFallida("Ya existe un cliente registrado con la misma cedula", 400);
                }

                Cliente clienteEntity = new Cliente();

                clienteEntity.Activo = true;
                clienteEntity.NombreCliente = clienteRequest.NombreCliente;
                clienteEntity.Cedula = clienteRequest.Cedula;
                clienteEntity.Direccion = clienteRequest.Direccion;
                clienteEntity.Telefono = clienteRequest.Telefono;


          
                clienteEntity.FechaCreacion = DateTime.Now;

                await _context.Cliente.AddAsync(clienteEntity);
                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se creo el cliente exitosamente!");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "ClienteResponse", "Hubo un  error interno al intentar crear");
            }

        }

        public async Task<ApiReponse> DeleteCliente(long id)
        {
            try
            {
                var clienteToDelete = await _context.Cliente.Where(x => x.Activo).FirstOrDefaultAsync();

                if (clienteToDelete == null)
                {
                    return infoReponse.AccionFallida("No existe el cliente que se intenta mostrar", 404);
                }

                clienteToDelete.Activo = false;

                clienteToDelete.FechaEliminacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se elimino el cliente exitosamente");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "ClienteResponse", "Hubo un error interno al intentar eliminar");
            }
            
            

        }

        public async Task<ApiReponse> EditarCliente(ClienteRequest clienteRequest)
        {
            try
            {
                var clienteToUpdate = await _context.Cliente.Where(x => x.Activo).FirstOrDefaultAsync();

                if (clienteToUpdate == null)
                {
                    return infoReponse.AccionFallida("Hubo un error interno al intentar editar", 404);
                }

                clienteToUpdate.NombreCliente = clienteRequest.NombreCliente;
                clienteToUpdate.Cedula = clienteRequest.Cedula;
                clienteToUpdate.Telefono = clienteRequest.Telefono;
                clienteToUpdate.Direccion = clienteRequest.Direccion;

                clienteToUpdate.FechaModificacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se edito el cliente exitosamente");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "ClienteResponse", "Hubo un error interno al intentar editar");
            }

        }

        public async Task<List<ClienteRequest>> GetAllCLientes()
        {
            var clienteList = await _context.Cliente.AsNoTracking().Where(x => x.Activo).Select(c => new ClienteRequest
            {
                IdCliente = c.IdCliente,
                Cedula = c.Cedula,
                NombreCliente = c.NombreCliente,
                Telefono = c.Telefono,
                Direccion = c.Direccion,

            }).ToListAsync();

            return clienteList;
        }

        public async Task<ClienteRequest> GetCliente(long id)
        {
            var clienteRequest = await _context.Cliente.AsNoTracking().Where(x => x.Activo && x.IdCliente == id).Select(c => new ClienteRequest
            {
                IdCliente = c.IdCliente,
                Cedula = c.Cedula,
                NombreCliente = c.NombreCliente,
                Telefono = c.Telefono,
                Direccion = c.Direccion,

            }).FirstOrDefaultAsync() ?? throw new ArgumentException("No se encontro la informacion solicitada");

            return clienteRequest;
        }

        public async Task<List<SecondValueLabelRequest>> SelectorCliente()
        {
            var selectorCliente = await _context.Cliente.AsNoTracking().Where(x => x.Activo).Select(c => new SecondValueLabelRequest
            {
                Value = c.IdCliente,
                Label = c.NombreCliente,
            }).ToListAsync();

            return selectorCliente;
        }
    }
}
