using AppParqueadero.Aplicaciones.Excepciones;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Net;
using System.Threading.Tasks;

namespace AppParqueadero.infraestructura.API.Middleware
{
    public class ExceptionManagerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionManagerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var detalle = new DetalleError() { type = exception.GetType(), traceId = Guid.NewGuid() };
            dynamic clase = new ExpandoObject();
            Errors errors = new Errors();
        var bb = exception is ValidarExceptions;
            switch (exception)
            {
                case ValidarExceptions e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    detalle.status = (int)HttpStatusCode.BadRequest;
                    detalle.title = "Datos no validos";
                    errors.DatosNovalidos.Add(e.Message);
                    detalle.errors  = errors;
                    break;
                case ValidatorDTO e:
                    context.Response.StatusCode = (int)HttpStatusCode.Accepted;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    detalle.status = (int)HttpStatusCode.BadRequest;
                    detalle.title = "Error en el servidor";
                    errors.DatosNovalidos.Add(exception.Message);
                    detalle.errors = errors;
                    break;
            }
            return context.Response.WriteAsync(JsonConvert.SerializeObject(detalle));
        }

    }

    public class DetalleError {
        public Type type { get; set; }
        public int status { get; set; }
        public string title { get; set; }
        public Guid traceId { get; set; }
        public Errors errors { get; set; }
    }

    public class Errors
    {
        public List<string> DatosNovalidos { get; set; }
        public Errors()
        {
            DatosNovalidos = new List<string>();
        }
    }
}
