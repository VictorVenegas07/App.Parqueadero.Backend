using AppParqueadero.Aplicaciones.Excepciones;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class TicketService : ITicketService<Ticket, Guid>
    {
        ITicketRepositorio<Ticket, Guid> repositorioTicket;
        IRepositorioBase<Empleado, Guid> repositorioEmpleado;
        IRepositorioBase<Puesto, Guid> repositorioPuesto;
        IRepositorioBase<Tarifa, Guid> repositorioTarifa;
        IRepositorioBase<Cliente, Guid> repositorioCliente;
        IRepositorioBase<Vehiculo, Guid> repositorioVehiculo;
        public TicketService(
            ITicketRepositorio<Ticket, Guid> repositorioTicket,
            IRepositorioBase<Empleado, Guid> repositorioEmpleado,
            IRepositorioBase<Puesto, Guid> repositorioPuesto,
            IRepositorioBase<Tarifa, Guid> repositorioTarifa,
            IRepositorioBase<Cliente, Guid> repositorioCliente,
            IRepositorioBase<Vehiculo, Guid> repositorioVehiculo
            )
        {
            this.repositorioTicket = repositorioTicket;
            this.repositorioEmpleado = repositorioEmpleado;
            this.repositorioPuesto = repositorioPuesto;
            this.repositorioTarifa = repositorioTarifa;
            this.repositorioCliente = repositorioCliente;
            this.repositorioVehiculo = repositorioVehiculo;
        }

        public Ticket Agregar(Ticket entidad)
        {
            ValidarTicket(entidad);
            entidad.Actualizar("Entrada");
            var response = repositorioTicket.Agregar(entidad);
            repositorioTicket.GuardarTodosLosCambios();
            return response;
            
        }
        private void ValidarTicket(Ticket ticket)
        {
            var puesto = repositorioPuesto.Consultar(x=> x.PuestoId == ticket.PuestoId && x.Disponibilidad == "Disponible").FirstOrDefault();
            var cliente = repositorioCliente.Consultar(x=> x.Identificacion == ticket.Cliente.Identificacion).FirstOrDefault();
            var vehiculo = repositorioVehiculo.Consultar(x => x.Placa == ticket.Vehiculo.Placa).FirstOrDefault();
            var tarifa = repositorioTarifa.SeleccionarPorId(ticket.TarifaId);
            var empleado = repositorioEmpleado.SeleccionarPorId(ticket.EmpleadoId);
            var vehiculoTicket = repositorioTicket.Consultar(x => x.Vehiculo.Placa == ticket.Vehiculo.Placa && x.Estado == "Entrada").FirstOrDefault();


            if (vehiculoTicket is not null)
                throw new ValidarExceptions($"El vehiculo con matricula {ticket.Vehiculo.Placa} ya tiene un ticket pendiente");

            if (empleado is null)
                throw new ValidarExceptions($"El codigo del empleado {ticket.EmpleadoId} no existe");

            if (puesto is null)
                throw new ValidarExceptions($"El puesto con codigo{ticket.PuestoId} no esta disponible");

            if (tarifa is null)
                throw new ValidarExceptions($"la tarifa con codigo {ticket.TarifaId} no existe");

            if (cliente is not null)
                ticket.Cliente = cliente;


            if (vehiculo is not null)
                ticket.Vehiculo = vehiculo;
            else
                ticket.Vehiculo.cliente = ticket.Cliente;

        }

        public void Eliminar(Guid entidad)
        {
            var response = repositorioTicket.SeleccionarPorId(entidad);
            if (response is not null)
                repositorioTicket.Eliminar(response);
            else
                throw new ValidarExceptions($"El ticket que desea eliminar no existe");

            repositorioTarifa.GuardarTodosLosCambios();
        }

        public List<Ticket> Listar()
        {
            var response = repositorioTicket.Listar();
            if (response is null)
                throw new ValidarExceptions("No hay tickets");

            return response;
                
        }

        public Ticket SeleccionarPorId(Guid entidad)
        {
            var res = repositorioTicket.SeleccionarPorId(entidad);
            if (res is null)
                throw new ValidarExceptions($"el ticket que busca no existe");

            return res;
        }

        public Ticket ActualizarEstado(Guid id)
        {
            Ticket response = ValidarEstado(id);
            response.Actualizar("Salida");
            response.CalcularTotal();
            var ticket = repositorioTicket.ActualizarEstado(response, id);
            repositorioTarifa.GuardarTodosLosCambios();
            return ticket;
        }

        private Ticket ValidarEstado(Guid id)
        {
            var response = repositorioTicket.Consultar(x => x.TickedId == id && x.Estado == "Entrada").FirstOrDefault();
            if (response is null)
                throw new ValidarExceptions($"El ticket no es valido");
            return response;
        }
    }
}
