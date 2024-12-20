﻿using MacroVentasEnterprise.Data;
using Microsoft.Extensions.Logging;
using NLog;
using System.Text.Json.Serialization;

namespace MacroVentasEnterprise.Response
{
    public class ApiReponse
    {
        [JsonIgnore]
        private static Logger? _log;
        public string? Message { get; set; }
        public string? User { get; set; }
        public long IdUser { get; set; }
        public dynamic? Detail { get; set; }
        public bool Success { get; set; } = true;
        public int Status { get; set; }

        public ApiReponse ErrorInterno(Exception ex, string nombre, string mensaje)
        {
            _log = LogManager.GetLogger(nombre);

            Message = mensaje;
            Detail = "Message: " + ex.Message + " InnerException: " + ex.InnerException;
            _log.Error($"{mensaje} : {ex.Message}\nInnerException: {ex.InnerException}\nStacktrace: {ex.StackTrace}");
            Success = false;
         
            Status = StatusCodes.Status500InternalServerError;
            return this;

        }
        public ApiReponse AccionCompletada(string mensaje)
        {
            Status = StatusCodes.Status200OK;
            Message = mensaje;
            Success = true;
            return this;
        }

        public ApiReponse AccionCompletadaLoginUsuario(string mensaje, string user, long idUser)
        {
            Status = StatusCodes.Status200OK;
            Message = mensaje;
            User = user;
            IdUser = idUser;
            Success = true;
            return this;
        }


        public ApiReponse AccionFallida(string mensaje, int status)
        {
            _log = LogManager.GetLogger(mensaje);

            Message = mensaje;
            Success = false;
            Status = status;
            return this;
        }
    }
}
