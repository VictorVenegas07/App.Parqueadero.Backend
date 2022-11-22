using AppParquadero.Infraestructura.Datos.Contexto;
using AppParquadero.Infraestructura.Datos.Repositorios;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio;
using AppParqueadero.infraestructura.API.Models.Reserva;
using AppParqueadero.Infraestructura.Datos.Repositorios;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ServicioReserva servicio;
        private readonly ReservaRepositorio repositorioReserva;
        private readonly ClienteRepositorio clienteRepositorio;
        private readonly PuestoRepositorio puestoRepositorio;
        private readonly VehiculoRepositorio vehiculoRepositorio;
        private readonly IMapper mapper;
        public ReservaController(ParqueaderoContexto contexto, IMapper mapper_)
        {
            repositorioReserva = new ReservaRepositorio(contexto);
            clienteRepositorio = new ClienteRepositorio(contexto);
            puestoRepositorio = new PuestoRepositorio(contexto);
            vehiculoRepositorio = new VehiculoRepositorio(contexto);
            servicio = new ServicioReserva(repositorioReserva, vehiculoRepositorio, clienteRepositorio, puestoRepositorio);
            mapper = mapper_;
        }
        // GET: api/<ReservaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> Get()
        {
            return Ok(servicio.Listar());
        }

        // GET api/<ReservaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetId(Guid id)
        {
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<ReservaController>
        [HttpPost]
        public async Task<ActionResult<Reserva>> Post(ReservaModel value)
        {
        
            return Ok(servicio.Agregar(mapper.Map<Reserva>(value)));
        }

        // PUT api/<ReservaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
