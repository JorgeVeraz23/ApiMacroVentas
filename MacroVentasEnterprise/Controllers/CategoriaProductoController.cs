using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MacroVentasEnterprise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProductoController : ControllerBase
    {

        private CategoriaProductoInterface _categoriaProductoInterface;

        public CategoriaProductoController(CategoriaProductoInterface categoriaProductoInterface) 
        {
            _categoriaProductoInterface = categoriaProductoInterface;
        }


        [HttpGet("GetAllCategoriaProducto")]
        public async Task<ActionResult> GetAllCategoriaProducto()
        {
            try
            {

                var response = await _categoriaProductoInterface.GetAllProducto();

                return Ok(response);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SelectorCategoriaProducto")]
        public async Task<ActionResult> SelectorCategoriaProducto()
        {
            try
            {

                var response = await _categoriaProductoInterface.SelectorCategoriaProducto();

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategoriaProductoById")]
        public async Task<ActionResult> GetCategoriaProductoById(long id)
        {
            try
            {

                var response = await _categoriaProductoInterface.GetCategoriaProductoById(id);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("CrearCategoriaProducto")]
        public async Task<ActionResult> CrearCategoriaProducto(CrearCategoriaProductoRequest categoriaProductoRequest)
        {
            try
            {

                var response = await _categoriaProductoInterface.CrearCategoria(categoriaProductoRequest);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ActualizarCategoriaProducto")]
        public async Task<ActionResult> ActualizarCategoriaProducto(CrearCategoriaProductoRequest categoriaProductoRequest)
        {
            try
            {
                var response = await _categoriaProductoInterface.EditarCategoria(categoriaProductoRequest);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("EliminarCategoriaProducto")]
        public async Task<ActionResult> EliminarCategoriaProducto(long id)
        {
            try
            {
                var response = await _categoriaProductoInterface.EliminarCategoria(id);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
