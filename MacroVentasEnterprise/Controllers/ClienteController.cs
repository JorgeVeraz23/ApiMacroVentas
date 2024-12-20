﻿using MacroVentasEnterprise.DTO;
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


        [HttpGet("SelectorClientes")]
        public async Task<ActionResult> SelectorCliente()
        {
            try
            {
                var response = await _clienteInterface.SelectorCliente();

                return Ok(response);
            }
            catch(Exception ex)
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
        public async Task<ActionResult> CrearCliente(ClienteRequest clienteRequest)
        {
            try
            {

                var response = await _clienteInterface.CrearCliente(clienteRequest);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("ActualizarCliente")]
        public async Task<ActionResult> ActualizarCliente(ClienteRequest clienteRequest)
        {
            try
            {

                var response = await _clienteInterface.EditarCliente(clienteRequest);

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("EliminarCliente")]
        public async Task<ActionResult> EliminarCliente(long id)
        {
            try
            {

                var response = await _clienteInterface.DeleteCliente(id);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
