using Microsoft.AspNetCore.Mvc;
using AppParqueadero.Dominio;
using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParquadero.Infraestructura.Datos.Repositorios;
using System.Collections.Generic;
using AutoMapper;
using System;
using AppParqueadero.infraestructura.API.Models.Vehiculo;
using Microsoft.AspNetCore.Authorization;
using System.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoiController : ControllerBase
    {
        VehiculoRepositorio repositorio;
        VehiculoServicio servicio;
        private readonly IMapper Mapper;


        public VehiculoiController(ParqueaderoContexto contexto, IMapper Mapper_)
        {
             repositorio = new VehiculoRepositorio(contexto);
             servicio = new VehiculoServicio(repositorio);
            Mapper = Mapper_;
        }
        // GET: api/<VehiculoiController>
        [HttpGet]
        public ActionResult<IEnumerable<Vehiculo>> Get()
        {
            return Ok(servicio.Listar());
        }

        // GET api/<VehiculoiController>/5
        [HttpGet("{id}")]
        public ActionResult<Vehiculo> Get(string id)
        {
            return Ok(servicio.SeleccionarPorId(Guid.Parse(id)));
        }

        // POST api/<VehiculoiController>
        [HttpPost]
        public ActionResult<Vehiculo> Post(VehiculoInput vehiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ValidationProblemDetails(ModelState));

            return Ok(servicio.Agregar(Mapper.Map<Vehiculo>(vehiculo)));
        }

        // PUT api/<VehiculoiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, VehiculoModels value)
        {
            servicio.Editar(Mapper.Map<Vehiculo>(value), Guid.Parse(id));
            return Ok("Editado correctamente");
        }

        // DELETE api/<VehiculoiController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            servicio.Eliminar(Guid.Parse(id));
            return Ok("Eliminado correctamente");
        }
        [HttpGet("/Placa/{id}")]
        public ActionResult<Vehiculo> GetQery(string id)
        {
            return Ok(servicio.BuscarPlata(id));
        }
    }
}
