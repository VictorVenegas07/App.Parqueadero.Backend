using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        ServicioEstadistica servicio;
        EstadisticaRepositori repositori;
        public EstadisticaController(ParqueaderoContexto contexto)
        {
            repositori = new EstadisticaRepositori(contexto);
            servicio = new ServicioEstadistica(repositori);
        }
        // GET: api/<EstadisticaController>
        [HttpGet("Productividad")]
        public ActionResult<Estadistica> GetProductividad()
        {
           var productividad = servicio.Productividad();
            return Ok(productividad);
        }
        [HttpGet("TotalGeneradoMensual")]
        public ActionResult<IEnumerable<TotalGeneradoCadaMes>> GetTotalGeneradoCadaMes()
        {
            var totalGenerado = servicio.TotalGeneradoCadaMes();
            return Ok(totalGenerado);
        }
        [HttpGet("VehiculosMasUsados")]
        public ActionResult<IEnumerable<VehiculosMasUsados>> GetVehiculosMasUsados()
        {
            var masUsados = servicio.VehiculosMasUsados();
            return Ok(masUsados);
        }


    }
}
