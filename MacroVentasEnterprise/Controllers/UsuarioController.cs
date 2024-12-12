using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MacroVentasEnterprise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioInterface _usuarioInterface;

        public UsuarioController(UsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("GetAllUsuarios")]
        public async Task<ActionResult> GetAllUsuarios()
        {
            try
            {

                var response = await _usuarioInterface.GetAllUsuarios();

                return Ok(response);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetUsuarioById")]
        public async Task<ActionResult> GetUsuarioById(long id)
        {
            try
            {
                var response = await _usuarioInterface.GetUsuarioById(id);

                return Ok(response);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SelectorUsuario")]
        public async Task<ActionResult> SelectorUsuario()
        {
            try
            {

                var response = await _usuarioInterface.SelectorUsuarios();

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CrearUsuarios")]
        public async Task<ActionResult> CrearUsuarios(UsuarioRequest usuarioInterface)
        {
            try
            {

                var response = await _usuarioInterface.CreateUsuario(usuarioInterface);

                return Ok(response);


            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Login")]
        public async Task<ActionResult> Login(string correo, string contrasenia)
        {
            try
            {

                var response = await _usuarioInterface.LoginUsuario(correo, contrasenia);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("ActualizarUsuarios")]
        public async Task<ActionResult> ActualizarUsuarios(UsuarioRequest usuarioRequest)
        {
            try
            {

                var response = await _usuarioInterface.EditarUsuario(usuarioRequest);


                return Ok(response);

            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete("EliminarUsuarios")]
        public async Task<ActionResult> EliminarUsuarios(long id)
        {
            try
            {

                var response = await _usuarioInterface.EliminarUsuario(id);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
