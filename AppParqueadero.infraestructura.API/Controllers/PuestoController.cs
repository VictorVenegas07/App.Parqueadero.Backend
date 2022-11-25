using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using AppParqueadero.infraestructura.API.Models.Puesto;
using AppParqueadero.infraestructura.API.Models.Tarifa;
using AppParqueadero.Infraestructura.Datos.Repositorios;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly PuestoRepositorio repositorio;
        private readonly PuestoService service;
        private readonly IMapper Mapper;
        public PuestoController(ParqueaderoContexto contexto,IMapper mapper_ )
        {
            repositorio = new PuestoRepositorio(contexto);
            service = new PuestoService(repositorio);
            Mapper = mapper_;
        }
        // GET: api/<PuestoController>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Puesto>> Get()
        {
            return Ok(service.Listar());
        }

        // GET api/<PuestoController>/5
        [HttpGet("{id}")]
        public ActionResult<Puesto> Get(string id)
        {
            return Ok(service.SeleccionarPorId(Guid.Parse(id)));
        }

        // POST api/<PuestoController>
        [HttpPost]
        public ActionResult<Puesto> Post(InputPuesto value)
        {
            return Ok(service.Agregar(Mapper.Map<Puesto>(value)));
        }

        // PUT api/<PuestoController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(string id, InputPuesto value)
        {
            service.Editar(Mapper.Map<Puesto>(value), Guid.Parse(id));
            return Ok("Datos Actualizados con exito");
        }

        // DELETE api/<PuestoController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            service.Eliminar(Guid.Parse(id));
            return Ok("Se a eliminado correctamente");
        }
    }
}
