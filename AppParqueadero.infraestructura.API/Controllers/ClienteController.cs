using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using AppParqueadero.Dominio;
using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParquadero.Infraestructura.Datos.Repositorios;
using System;
using AppParqueadero.infraestructura.API.Models.Cliente;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteRepositorio repositorio;
        ServicioCliente servicio;
        private readonly IMapper Mapper;

        public ClienteController(ParqueaderoContexto contexto, IMapper mapper_)
        {
            repositorio = new ClienteRepositorio(contexto);
            servicio = new ServicioCliente(repositorio);
            Mapper = mapper_;
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
        public ActionResult Post(ClienteModels cliente)
        {
            return Ok(servicio.Agregar(Mapper.Map<Cliente>(cliente)));
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, ClienteModels cliente)
        {
            servicio.Editar(Mapper.Map<Cliente>(cliente), Guid.Parse(id));
            return Ok("Datos actualizados");
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            servicio.Eliminar(id);
            return Ok("Se elimino correctamente");
        }
        [AllowAnonymous]
        [HttpGet("/identificacion/{id}")]
        public ActionResult<ViewCliente> GetIdentificacion(string id)
        {
           var res=  servicio.BuscarIdentificacion(id);
            return Ok(Mapper.Map<ViewCliente>(res));
        }
    }
}
