using AppParqueadero.Aplicaciones.Excepciones;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
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
            var detalle = new DetalleError() { Message = exception.Message, StackTrace = exception.StackTrace};
            var bb = exception is ValidarExceptions;
            switch (exception)
            {
                case ValidarExceptions e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    detalle.StatusCode = (int)HttpStatusCode.BadRequest;
                    detalle.Message = e.Message;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    detalle.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }
            return context.Response.WriteAsync(JsonConvert.SerializeObject(detalle));
        }

    }

    public class DetalleError {

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string  StackTrace { get; set; }
    }
}
