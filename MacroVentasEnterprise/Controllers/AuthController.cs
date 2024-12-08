using MacroVentasEnterprise.Data;
using MacroVentasEnterprise.Service;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.DTO;

namespace MacroVentasEnterprise.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        private readonly JwtService _jwtService;

        public AuthController(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO model)
        {
            // Verificar que el usuario exista
            var user = await _userManager.FindByNameAsync(model.Correo);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            // Verificar que la contraseña sea correcta
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid credentials");
            }

            // Generar el JWT
            var token = await _jwtService.GenerateTokenAsync(user);

            // Retornar el token JWT
            return Ok(new { token });
        }

          // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserDTO model)
        {
            try
            {
                //// Verificar si las contraseñas coinciden
                //if (model.Password == null)
                //{
                //    return BadRequest("Passwords do not match");
                //}

                // Crear un nuevo ApplicationUser con los datos del DTO
                var user = new ApplicationUser
                {
                    Contraseña = model.Password,
                    UserName = model.Correo,
                    Correo = model.Correo,
                    Identitificacion = model.Identitificacion,
                    Telefono = model.Telefono,

                };

                // Llamar al repositorio para crear el usuario
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok(new { message = "Usuario Registrado Exitosamente" });
                }

                return BadRequest(result.Errors);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
