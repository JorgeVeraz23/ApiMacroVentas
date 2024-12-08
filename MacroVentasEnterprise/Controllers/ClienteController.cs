using MacroVentasEnterprise.DTO;
using MacroVentasEnterprise.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MacroVentasEnterprise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteInterface _clienteInterface;

        public ClienteController(ClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }


        [HttpGet("GetAllClientes")]
        public async Task<ActionResult> GetAllClientes()
        {
            try
            {

                var response = await _clienteInterface.GetAllCLientes();

                return Ok(response);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(long id)
        {
            try
            {

                var response = await _clienteInterface.GetCliente(id);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CrearCliente")]
        public async Task<ActionResult> CrearCliente(ClienteDTO clienteDTO)
        {
            try
            {

                var response = await _clienteInterface.CrearCliente(clienteDTO);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
