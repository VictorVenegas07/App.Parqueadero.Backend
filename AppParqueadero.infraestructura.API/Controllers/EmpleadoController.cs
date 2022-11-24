using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models.Empleado;
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
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpledoRepositorio repositorio;
        private readonly EmpleadoService service;
        private readonly IMapper Mapper;
        public EmpleadoController(ParqueaderoContexto contexto, IMapper mapper_)
        {
            repositorio = new EmpledoRepositorio(contexto);
            service = new EmpleadoService(repositorio);
            Mapper = mapper_;
        }
        // GET: api/<EmpleadoController>
        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> Get()
        {
            return Ok(service.Listar());
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public ActionResult<Empleado> Get(string id)
        {
            return Ok(service.SeleccionarPorId(Guid.Parse(id)));
        }
    

        // POST api/<EmpleadoController>
        [HttpPost]
        public ActionResult<Empleado> Post(EmpleadoInput value)
        {
            return Ok(service.Agregar(Mapper.Map<Empleado>(value)));
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(string id, UpdateEmpleado value)
        {
            service.Editar(Mapper.Map<Empleado>(value), Guid.Parse(id));
            return Ok("Datos Actualizados con exito");
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            service.Eliminar(Guid.Parse(id));
            return Ok("Se a eliminado correctamente");
        }
    }
}
