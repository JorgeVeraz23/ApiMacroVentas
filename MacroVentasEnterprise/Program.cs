using MacroVentasEnterprise;
using MacroVentasEnterprise.Data;
using MacroVentasEnterprise.Interfaces;
using MacroVentasEnterprise.Logica;
using MacroVentasEnterprise.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    //// Configuración para permitir la inclusión del token JWT
    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.ApiKey,
    //    Scheme = "Bearer",
    //    BearerFormat = "JWT",
    //    Description = "Ingrese 'Bearer' seguido de un espacio y el token JWT"
    //});

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Configura el DbContext con el proveedor adecuado (por ejemplo, SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ClienteInterface, ClienteRepository>();
builder.Services.AddScoped<UsuarioInterface, UsuarioRepository>();


// Agrega servicios para controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}




app.UseHttpsRedirection();
//app.UseRouting();
app.UseAuthentication();  // Usar autenticación JWT
app.UseAuthorization();

app.MapControllers();

app.Run();
