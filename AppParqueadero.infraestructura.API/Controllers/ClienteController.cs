using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using AppParqueadero.Dominio;
using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParquadero.Infraestructura.Datos.Repositorios;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteRepositorio repositorio;
        ServicioCliente servicio;

        public ClienteController(ParqueaderoContexto contexto)
        {
            repositorio = new ClienteRepositorio(contexto);
            servicio = new ServicioCliente(repositorio);
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return Ok(servicio.Listar());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(Guid id)
        {
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            return Ok(servicio.Agregar(cliente));
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cliente cliente)
        {
            cliente.ClienteId = id;
            servicio.Editar(cliente);
            return Ok("Datos actualizados");
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            servicio.Eliminar(id);
            return Ok("Se elimino correctamente");
        }
    }
}
