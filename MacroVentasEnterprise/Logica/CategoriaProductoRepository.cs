using MacroVentasEnterprise.Data;
using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Request;
using MacroVentasEnterprise.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MacroVentasEnterprise.Logica
{
    public class CategoriaProductoRepository : CategoriaProductoInterface
    {

        private readonly ApplicationDbContext _context;

        private ApiReponse infoReponse = new ApiReponse();


        public CategoriaProductoRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<ApiReponse> CrearCategoria(CrearCategoriaProductoRequest categoriaProductoResponse)
        {
            try
            {
                var ifExist = await _context.CategoriaProductos.Where(x => x.Activo && x.NombreCategoria.ToUpper().Equals(categoriaProductoResponse.NombreCategoria)).FirstOrDefaultAsync();

                if (ifExist != null)
                {
                    return infoReponse.AccionFallida("Ya existe una categoria creada con el mismo nombre", 400);
                }

                CategoriaProducto categoriaProducto = new CategoriaProducto();

                categoriaProducto.Activo = true;

                categoriaProducto.NombreCategoria = categoriaProductoResponse.NombreCategoria;
                categoriaProducto.Descripcion = categoriaProductoResponse.Descripcion;

                categoriaProducto.FechaCreacion = DateTime.Now;

                await _context.CategoriaProductos.AddAsync(categoriaProducto);
                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se creo la categoria exitosamente");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno al intentar crear", "500");
            }
            
        }

        public async Task<ApiReponse> EditarCategoria(CrearCategoriaProductoRequest categoriaProductoResponse)
        {
            try
            {
                var model = await _context.CategoriaProductos.Where(x => x.Activo && x.IdCategoriaProducto == categoriaProductoResponse.IdCategoriaProducto).FirstOrDefaultAsync();

                if (model == null)
                {
                    return infoReponse.AccionFallida("No se encontro la categoria que se intenta editar", 404);
                }

                model.NombreCategoria = categoriaProductoResponse.NombreCategoria;
                model.Descripcion = categoriaProductoResponse.Descripcion;

                model.FechaModificacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se edito la categoria");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno", "400");
            }
        }



        public async Task<ApiReponse> EliminarCategoria(long id)
        {
            try
            {
                var categoriaToDelete = await _context.CategoriaProductos.Where(x => x.Activo && x.IdCategoriaProducto == id).FirstOrDefaultAsync();

                categoriaToDelete.Activo = false;
                categoriaToDelete.FechaEliminacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return infoReponse.AccionCompletada("Se elimino la categoria exitosamente");
            }catch(Exception ex)
            {
                return infoReponse.ErrorInterno(ex, "Hubo un error interno al intentar eliminar", "500");
            }
        }



        public async Task<List<CategoriaProductoRequest>> GetAllProducto()
        {
            var categoriaProductoList = await _context.CategoriaProductos.AsNoTracking().Where(x => x.Activo).Select(c => new CategoriaProductoRequest
            {
                IdCategoriaProducto = c.IdCategoriaProducto,
                NombreCategoria = c.NombreCategoria,
                Descripcion = c.Descripcion,
                Productos = c.Productos.Select(c => new ProductoRequest
                {
                    IdProducto = c.IdProducto,
                    NombreProducto = c.NombreProducto,
                    CodigoProducto = c.CodigoProducto,
                    Precio = c.Precio,
                    Stock = c.Stock,
                }).ToList()
            }).ToListAsync();

            return categoriaProductoList;
        }

        public async Task<CategoriaProductoRequest> GetCategoriaProductoById(long id)
        {
            var categoriaProductoList = await _context.CategoriaProductos.AsNoTracking().Where(x => x.Activo && x.IdCategoriaProducto == id).Select(c => new CategoriaProductoRequest
            {
                IdCategoriaProducto = c.IdCategoriaProducto,
                NombreCategoria = c.NombreCategoria,
                Descripcion = c.Descripcion,
                Productos = c.Productos.Select(c => new ProductoRequest
                {
                    IdProducto = c.IdProducto,
                    NombreProducto = c.NombreProducto,
                    CodigoProducto = c.CodigoProducto,
                    Precio = c.Precio,
                    Stock = c.Stock,
                }).ToList()
            }).FirstOrDefaultAsync() ?? throw new ArgumentNullException("No se encontro el producto especificado");

            return categoriaProductoList;
        }

        public async Task<List<ValueLabelRequest>> SelectorCategoriaProducto()
        {
            var response = await _context.CategoriaProductos.Select(c => new ValueLabelRequest
            {
                Value = c.IdCategoriaProducto.ToString(),
                Label = c.NombreCategoria,
            }).ToListAsync();

            return response;
        }
    }
}
