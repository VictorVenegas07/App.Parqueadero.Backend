using Microsoft.AspNetCore.Mvc;
using AppParqueadero.Dominio;
using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParquadero.Infraestructura.Datos.Repositorios;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoiController : ControllerBase
    {
        VehiculoRepositorio repositorio;
        VehiculoServicio servicio;

        public VehiculoiController(ParqueaderoContexto contexto)
        {
             repositorio = new VehiculoRepositorio(contexto);
             servicio = new VehiculoServicio(repositorio);
        }
        // GET: api/<VehiculoiController>
        [HttpGet]
        public ActionResult<IEnumerable<Vehiculo>> Get()
        {
            return Ok(servicio.Listar());
        }

        // GET api/<VehiculoiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehiculoiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehiculoiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehiculoiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
