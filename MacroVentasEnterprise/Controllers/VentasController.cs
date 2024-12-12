using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MacroVentasEnterprise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly VentaInterface _ventaInterface;

        public VentasController(VentaInterface ventaInterface)
        {
            _ventaInterface = ventaInterface;
        }


        [HttpGet("GetAllVentas")]
        public async Task<ActionResult> GetAllVentas()
        {
            try
            {
                var response = await _ventaInterface.GetAllVentas();

                return Ok(response);    
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetVentaByID")]
        public async Task<ActionResult> GetVentaByID(long id)
        {
            try
            {
                var response = await _ventaInterface.GetVentaById(id);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerReporte")]
        public async Task<ActionResult> ObtenerReporte(DateTime? FechaInicio,  DateTime? FechaFin)
        {
            try
            {
                var response = await _ventaInterface.ObtenerReporte(FechaInicio, FechaFin);

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("CrearVenta")]
        public async Task<ActionResult> CrearVenta(VentaRequest ventaRequest)
        {
            try
            {
                var response = await _ventaInterface.CrearVenta(ventaRequest);

                return Ok(response);


            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ActualizarFactura")]
        public async Task<ActionResult> ActualizarFactura(VentaRequest ventaRequest)
        {
            try
            {

                var response = await _ventaInterface.EditarVenta(ventaRequest);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
