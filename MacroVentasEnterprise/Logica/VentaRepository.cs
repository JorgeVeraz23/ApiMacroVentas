using Azure.Core;
using Azure;
using MacroVentasEnterprise.Data;
using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Request;
using MacroVentasEnterprise.Response;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace MacroVentasEnterprise.Logica
{
    public class VentaRepository : VentaInterface
    {

        private readonly ApplicationDbContext _context;

        private ApiReponse infoReponse = new ApiReponse();

        public VentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiReponse> CrearVenta(VentaRequest ventaRequest)
        {
            try
            {
                Ventas ventas = new Ventas
                {
                    FechaCreacion = DateTime.Now,
                    Activo = true,
                    VentaDetalles = new Collection<VentaDetalle>()
                };

                ventas.IVA = ventaRequest.IVA;
                ventas.UserId = ventaRequest.UserId;
                ventas.Activo = true;
                ventas.FechaCreacion = DateTime.Now;
                ventas.IdCliente = ventaRequest.IdCliente;
               

                foreach (var item in ventaRequest.VentaDetalles!)
                {
                    var prePro = await _context.Producto.Where(x => x.Activo && x.IdProducto == item.IdProducto).Select(c => c.Precio).FirstOrDefaultAsync();

                    VentaDetalle ventaDetalle = new VentaDetalle
                    {
                        Activo = true,
                        Cantidad = item.Cantidad,
                        SubTotal = item.Cantidad * prePro,
                        IdProducto = item.IdProducto,
                        IdVentas = item.IdVentas,
                       
                        FechaCreacion = DateTime.Now,
                    };
                    ventas.VentaDetalles.Add(ventaDetalle);

                    //Aqui agrego el subtotal al total de la venta
                    ventas.TotalVenta += ventaDetalle.SubTotal;
                }



                await _context.Ventas.AddAsync(ventas);
                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se creo la factura exitosamente!");

            }catch (Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno", "500");
            }

        }

        public async Task<ApiReponse> EditarVenta(VentaRequest ventaRequest)
        {
            try
            {
                // Verificar si la venta existe
                var venta = await _context.Ventas
                    .Include(v => v.VentaDetalles)
                    .FirstOrDefaultAsync(v => v.IdVentas == ventaRequest.IdVentas);

                if (venta == null)
                {
                    return infoReponse.AccionFallida("No existe la venta que se intenta editar", 404);
                }

                // Actualizar detalles de la venta
                foreach (var detalleRequest in ventaRequest.VentaDetalles!)
                {
                    var precProd = await _context.Producto.Where(x => x.Activo && x.IdProducto == detalleRequest.IdProducto).Select(c => c.IdProducto).FirstOrDefaultAsync();
                    // Si el detalle ya existe, actualizarlo
                    var detalle = venta.VentaDetalles!.FirstOrDefault(d => d.IdVentaDetalle == detalleRequest.IdVentaDetalle);
                    if (detalle != null)
                    {
                        detalle.Cantidad = detalleRequest.Cantidad;
                        detalle.SubTotal = detalleRequest.SubTotal;
                    }
                    else
                    {
                        // Si no existe, agregar un nuevo detalle
                        venta.VentaDetalles!.Add(new VentaDetalle
                        {
                            IdProducto = detalleRequest.IdProducto,
                            Cantidad = detalleRequest.Cantidad,
                            SubTotal = detalleRequest.Cantidad * precProd,
                            FechaModificacion = DateTime.Now,
                        });
                    }
                }

    
                venta.TotalVenta = venta.VentaDetalles!.Sum(d => d.SubTotal);
                venta.IVA = venta.TotalVenta * 0.13m;


                venta.FechaModificacion = DateTime.Now;

       
                _context.Ventas.Update(venta);
                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se edito la venta exitosamente");
            }
            catch (Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno al intentar editar la venta", "500");
            }
        }

        public async Task<ApiReponse> EliminarVenta(long id)
        {
            try
            {
                var ventaToDelete = await _context.Ventas.Where(x => x.Activo && x.IdVentas == id).FirstOrDefaultAsync();

                if (ventaToDelete == null)
                {
                    return infoReponse.AccionFallida("No se encontro la venta que se intenta eliminar", 400);
                }

                ventaToDelete.Activo = false;
                ventaToDelete.FechaEliminacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se elimino la venta solicitada");
            }catch (Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno al intentar eliminar la factura", "500");
            }
        }



        public async Task<List<MostrarVentaRequest>> GetAllVentas()
        {
            var ventasConDetalles = await _context.Ventas.Where(x => x.Activo).Include(c => c.VentaDetalles).Select(c => new MostrarVentaRequest
            {
                IdVentas = c.IdVentas,
                Empleado = c.User.Nombre + " " + c.User.Apellido,
                IVA = c.IVA,
                TotalVenta = c.TotalVenta,
                VentaDetalles = c.VentaDetalles!.Select(x => new MostrarVentaDetalleRequest
                {
                    Cantidad = x.Cantidad,
                    NombreProducto = x.Producto.NombreProducto,
                    IdVentas = x.IdVentas,
                    SubTotal = x.SubTotal,
                    IdVentaDetalle = x.IdVentaDetalle
                }).ToList(),
            }).ToListAsync();



            return ventasConDetalles;
           
        }

        public async Task<MostrarVentaRequest> GetVentaById(long id)
        {
            var ventasConDetalles = await _context.Ventas.Where(x => x.Activo && x.IdVentas == id).Include(c => c.VentaDetalles).Select(c => new MostrarVentaRequest
            {
                IdVentas = c.IdVentas,
                Empleado = c.User.Nombre + " " + c.User.Apellido,
                IVA = c.IVA,
                TotalVenta = c.TotalVenta,
                VentaDetalles = c.VentaDetalles!.Select(x => new MostrarVentaDetalleRequest
                {
                    Cantidad = x.Cantidad,
                    NombreProducto = x.Producto.NombreProducto,
                    IdVentas = x.IdVentas,
                    SubTotal = x.SubTotal,
                    IdVentaDetalle = x.IdVentaDetalle
                }).ToList(),
            }).FirstOrDefaultAsync() ?? throw new ArgumentNullException("No se encontro al venta solicitada");



            return ventasConDetalles;
        }

        public Task<List<ValueLabelRequest>> SelectorVenta()
        {
            throw new NotImplementedException();
        }
    }
}
