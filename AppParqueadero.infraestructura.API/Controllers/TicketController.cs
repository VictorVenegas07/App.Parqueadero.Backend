using AppParquadero.Infraestructura.Datos.Contexto;
using AppParquadero.Infraestructura.Datos.Repositorios;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models.Ticket;
using AppParqueadero.Infraestructura.Datos.Repositorios;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Authorize]
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
        public ActionResult<IEnumerable<ViewTicketd>> Get()
        {
            var response = servicio.Listar();
            return Ok(response.Select(x => mapper.Map<ViewTicketd>(x)));
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public ActionResult<ViewTicketd> Get(Guid id)
        {
            return Ok(mapper.Map<ViewTicketd>(servicio.SeleccionarPorId(id)));
        }

        [HttpGet("Salida/{id}")]
        public ActionResult<Ticket> GetOuput(string id)
        {
            return Ok(servicio.ActualizarEstado(Guid.Parse(id)));
        }

        // POST api/<TicketController>
        [HttpPost]
        public ActionResult<Ticket> Post(TicketModels  ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ValidationProblemDetails(ModelState));

            return Ok(servicio.Agregar(mapper.Map<Ticket>(ticket)));
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            servicio.Eliminar(Guid.Parse(id));
            return Ok("Se a eliminado correctamente");
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ViewTicketd>> GetFiltrarTickets(DateTime? fecha,string identificacion, string? placa, string? estado)
        {
            var response = servicio.BuscarVarios(fecha,identificacion, placa, estado );
            return Ok(response.Select(x => mapper.Map<ViewTicketd>(x)));
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ViewTicketd>> ObtenerTicketEmpleado(string idEmpleado)
        {
            var response = servicio.TicketsEmpleado(Guid.Parse(idEmpleado));
            return Ok(response.Select(x => mapper.Map<ViewTicketd>(x)));
        }
    }
}
