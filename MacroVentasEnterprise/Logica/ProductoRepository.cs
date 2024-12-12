using MacroVentasEnterprise.Data;
using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Request;
using MacroVentasEnterprise.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MacroVentasEnterprise.Logica
{
    public class ProductoRepository : ProductoInterface
    {

        private ApplicationDbContext _context;
        private ApiReponse infoReponse = new ApiReponse();

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ApiReponse> CrearProducto(ProductoRequest productoRequest)
        {
            try
            {
                var ifExist = await _context.Producto.Where(x => x.Activo && x.NombreProducto.ToUpper().Equals(productoRequest.NombreProducto.ToUpper())).FirstOrDefaultAsync();

                if (ifExist != null)
                {
                    return infoReponse.AccionFallida("Ya existe un producto creado con el mismo nombre", 400);
                }

                Producto producto = new Producto();

                producto.Activo = true;
                producto.NombreProducto = productoRequest.NombreProducto;
                producto.CodigoProducto = productoRequest.CodigoProducto;
                producto.Precio = productoRequest.Precio;
                producto.Stock = productoRequest.Stock;
                producto.IdCategoria = productoRequest.idCategoriaProducto;

                producto.FechaCreacion = DateTime.Now;

                await _context.Producto.AddAsync(producto);

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se creo el producto de forma exitosa!");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno al intentar crear", "500");
            }


           
        }

        public async Task<ApiReponse> DeleteProducto(long id)
        {
            try
            {

                var productoToDelete = await _context.Producto.Where(x => x.Activo && x.IdProducto == id).FirstOrDefaultAsync();

                if(productoToDelete == null)
                {
                    return infoReponse.AccionFallida("No existe el producto que se intenta eliminar", 404);
                }

                productoToDelete.Activo = true;

                productoToDelete.FechaEliminacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se elimino el producto exitosamente!");



            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno al intentar eliminar", "400");
            }
        }

        public async Task<ApiReponse> EditarProducto(ProductoRequest productoRequest)
        {
            try
            {
                var model = await _context.Producto.Where(x => x.Activo && x.IdProducto == productoRequest.IdProducto).FirstOrDefaultAsync();

                if (model == null)
                {
                    return infoReponse.AccionFallida("No existe el producto que se intenta actualizar", 404);
                }

                model.NombreProducto = productoRequest.NombreProducto;
                model.CodigoProducto = productoRequest.CodigoProducto;
                model.Precio = productoRequest.Precio;
                model.Stock = productoRequest.Stock;
                model.IdCategoria = productoRequest.idCategoriaProducto;


                model.FechaModificacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se edito el producto correctamente");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno al intentar crear", "500");
            }
        }

        public async Task<List<ProductoRequest>> GetAllProducto()
        {
            var listaProducto = await _context.Producto.AsNoTracking().Where(x => x.Activo).Select(c => new ProductoRequest
            {
                IdProducto = c.IdProducto,
                NombreProducto = c.NombreProducto,
                CodigoProducto = c.CodigoProducto,
                Precio = c.Precio,
                Stock = c.Stock,
            }).ToListAsync();

            return listaProducto;
        }

        public async Task<ProductoRequest> GetProductoById(long id)
        {
            var productoSelected = await _context.Producto.AsNoTracking().Where(x => x.Activo && x.IdProducto == id).Select(c => new ProductoRequest
            {
                IdProducto = c.IdProducto,
                NombreProducto = c.NombreProducto,
                CodigoProducto = c.CodigoProducto,
                Precio = c.Precio,
                Stock = c.Stock,
            }).FirstOrDefaultAsync() ?? throw new ArgumentNullException("No existe el producto que se intenta obtener");

            return productoSelected;
        }

        public async Task<List<ValueLabelRequest>> SelectorProducto()
        {
            var selectorProducto = await _context.Producto.AsNoTracking().Where(x => x.Activo).Select(c => new ValueLabelRequest
            {
                Value = c.IdProducto.ToString(),
                Label = c.NombreProducto,
            }).ToListAsync();

            return selectorProducto;
        }
    }
}
