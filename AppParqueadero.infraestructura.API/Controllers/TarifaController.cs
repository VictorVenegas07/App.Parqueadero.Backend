using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models.Tarifa;
using AppParqueadero.Infraestructura.Datos.Repositorios;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifaController : ControllerBase
    {
        private readonly TarifaRepositori repositori;
        private readonly TarifaService service;
        private readonly IMapper mapper;
        public TarifaController(ParqueaderoContexto contexto,IMapper mappe_)
        {
            repositori = new TarifaRepositori(contexto);
            service = new TarifaService(repositori);
            mapper = mappe_;
        }
        // GET: api/<TarifaController>
        [HttpGet]
        public ActionResult<IEnumerable<Tarifa>> Get()
        {
            return Ok(service.Listar());
        }

        // GET api/<TarifaController>/5
        [HttpGet("{id}")]
        public ActionResult<Tarifa> Get(string id)
        {
            return Ok(service.SeleccionarPorId(Guid.Parse(id)));
        }

        // POST api/<TarifaController>
        [HttpPost]
        public ActionResult<Tarifa> Post(TarifaModels value)
        {
            return Ok(service.Agregar(mapper.Map<Tarifa>(value)));
        }

        // PUT api/<TarifaController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(string id, Tarifa value)
        {
            service.Editar(value, Guid.Parse(id));
            return Ok("Datos Actualizados con exito");
        }

        // DELETE api/<TarifaController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            service.Eliminar(Guid.Parse(id));
            return Ok("Se a eliminado correctamente");
        }
    }
}
