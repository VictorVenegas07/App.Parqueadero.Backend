using AppParquadero.Infraestructura.Datos.Contexto;
using AppParquadero.Infraestructura.Datos.Repositorios;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models.Reserva;
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
    public class ReservaController : ControllerBase
    {
        private readonly ServicioReserva servicio;
        private readonly ReservaRepositorio repositorioReserva;
        private readonly ClienteRepositorio clienteRepositorio;
        private readonly PuestoRepositorio puestoRepositorio;
        private readonly VehiculoRepositorio vehiculoRepositorio;
        private readonly TarifaRepositori tarifaRepositorio;

        private readonly IMapper mapper;
        public ReservaController(ParqueaderoContexto contexto, IMapper mapper_)
        {
            repositorioReserva = new ReservaRepositorio(contexto);
            clienteRepositorio = new ClienteRepositorio(contexto);
            puestoRepositorio = new PuestoRepositorio(contexto);
            vehiculoRepositorio = new VehiculoRepositorio(contexto);
            tarifaRepositorio = new TarifaRepositori(contexto);
            servicio = new ServicioReserva(repositorioReserva, vehiculoRepositorio, clienteRepositorio, puestoRepositorio, tarifaRepositorio);
            mapper = mapper_;
        }
        // GET: api/<ReservaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewReserva>>> Get()
        {
            return Ok(servicio.Listar().Select(x=> mapper.Map<ViewReserva>(x)));
        }

        // GET api/<ReservaController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetId(Guid id)
        {
            return Ok(mapper.Map<ViewReserva>(servicio.SeleccionarPorId(id)));
        }

        // POST api/<ReservaController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Reserva>> Post(ReservaModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ValidationProblemDetails(ModelState));

            return Ok(servicio.Agregar(mapper.Map<Reserva>(value)));
        }

        // PUT api/<ReservaController>/5
        [AllowAnonymous]
        [HttpGet("/Cliente/{id}")]
        public ActionResult<ViewReserva> GetReserva(string id)
        {
            var resp = servicio.BuscarReservaCliente(id);
            return Ok(resp.Select(x=> mapper.Map<ViewReserva>(x)));
        }

        // DELETE api/<ReservaController>/5
        [HttpPost("/Generar/Ticket")]
        public async Task<ActionResult<ViewTicketd>> PostGenerarTicket(TicketReserva reserva)
        {
           var response = await servicio.GenerarTicket(mapper.Map<Ticket>(reserva), reserva.ReservaId);
            return Ok(mapper.Map<ViewTicketd>(response));
        }

        [AllowAnonymous]
        [HttpGet("/Cancelar/{id}")]
        public ActionResult<ViewReserva> GetCancelarReserva(string id)
        {
            var resp = servicio.AnularReserva(Guid.Parse(id));
            return Ok(mapper.Map<ViewReserva>(resp));
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ViewReserva>> GetFiltrarReserva(DateTime? fecha, string identificacion, string? placa, string? estado)
        {
            var response = servicio.BuscarVarios(fecha, identificacion, placa, estado);
            return Ok(response.Select(x => mapper.Map<ViewReserva>(x)));
        }
    }
}
