using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MacroVentasEnterprise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly ProductoInterface _productoInterface;

        public ProductoController(ProductoInterface productoInterface)
        {
            _productoInterface = productoInterface; 
        }

        [HttpGet("GetAllProductos")]
        public async Task<ActionResult> GetAllProductos()
        {
            try
            {

                var response = await _productoInterface.GetAllProducto();

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetProductoById")]
        public async Task<ActionResult> GetProductoById(long id)
        {
            try
            {

                var response = await _productoInterface.GetProductoById(id);

                return Ok(response);    


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("SelectorProducto")]
        public async Task<ActionResult> SelectorProducto()
        {
            try
            {

                var response = await _productoInterface.SelectorProducto();

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("CrearProducto")]
        public async Task<ActionResult> CrearProducto(ProductoRequest productoRequest)
        {
            try
            {

                var response = await _productoInterface.CrearProducto(productoRequest);


                return Ok(response);    

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ActualizarProducto")]
        public async Task<ActionResult> ActualizarProducto(ProductoRequest productoRequest)
        {
            try
            {
                var response = await _productoInterface.EditarProducto(productoRequest);

                return Ok(response);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("EliminarProducto")]
        public async Task<ActionResult> EliminarProducto(long id)
        {
            try
            {

                var response = await _productoInterface.DeleteProducto(id);

                return Ok(response);
                
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
