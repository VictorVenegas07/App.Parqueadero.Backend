using AppParquadero.Infraestructura.Datos.Contexto;
using AppParquadero.Infraestructura.Datos.Repositorios;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models;
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
    public class TicketController : ControllerBase
    {
        private readonly TicketService servicio;
        private readonly TicketdRepositorio ticketdRepositorio;
        private readonly ClienteRepositorio clienteRepositorio;
        private readonly PuestoRepositorio puestoRepositorio;
        private readonly VehiculoRepositorio vehiculoRepositorio;
        private readonly TarifaRepositori tarifaRepositorio;
        private readonly EmpledoRepositorio empledoRepositorio;
        private readonly IMapper mapper;
        public TicketController(ParqueaderoContexto contexto, IMapper mapper_)
        {
            
            clienteRepositorio = new ClienteRepositorio(contexto);
            puestoRepositorio = new PuestoRepositorio(contexto);
            vehiculoRepositorio = new VehiculoRepositorio(contexto);
            tarifaRepositorio = new TarifaRepositori(contexto);
            empledoRepositorio = new EmpledoRepositorio(contexto);
            ticketdRepositorio = new TicketdRepositorio(contexto);
            servicio = new TicketService(ticketdRepositorio, empledoRepositorio,puestoRepositorio,tarifaRepositorio,clienteRepositorio,vehiculoRepositorio);

            mapper = mapper_;

        }

        // GET: api/<TicketController>
        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> Get()
        {
            return Ok(servicio.Listar());
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public ActionResult<Ticket> Get(Guid id)
        {
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<TicketController>
        [HttpPost]
        public ActionResult<Ticket> Post(TicketModels  ticket)
        {
            return Ok(servicio.Agregar(mapper.Map<Ticket>(ticket)));
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
