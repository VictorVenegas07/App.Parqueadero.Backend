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
            entidad.AsingarValores();
            ActualizarPuesto(entidad.Puesto, entidad.PuestoId, "Ocupado");
            var response = repositorioTicket.Agregar(entidad);
            repositorioTicket.GuardarTodosLosCambios();
            return response;
            
        }
        private void ValidarTicket(Ticket ticket)
        {

            ValidarTicketExistente(ticket);
            ValidarEmpleado(ticket);
            ValidarPuesto(ticket);
            ValidarTarifa(ticket);
            ValidarCliente(ticket);
            ValidarVehiculo(ticket);

        }

        private  void ValidarVehiculo(Ticket ticket)
        {
            var vehiculo = repositorioVehiculo.Consultar(x => x.Placa == ticket.Vehiculo.Placa).FirstOrDefault();

            if (vehiculo is not null)
                ticket.Vehiculo = vehiculo;
            else
                ticket.Vehiculo.cliente = ticket.Cliente;
        }

        private  void ValidarCliente(Ticket ticket )
        {
            var cliente = repositorioCliente.Consultar(x => x.Identificacion == ticket.Cliente.Identificacion).FirstOrDefault();
            if (cliente is not null)
                ticket.Cliente = cliente;
        }

        private void ValidarTarifa(Ticket ticket)
        {
            var tarifa = repositorioTarifa.SeleccionarPorId(ticket.TarifaId);

            if (tarifa is null)
                throw new ValidarExceptions($"la tarifa con codigo {ticket.TarifaId} no existe");
        }

        private  void ValidarPuesto(Ticket ticket)
        {
            var puesto = repositorioPuesto.Consultar(x => x.PuestoId == ticket.PuestoId && x.Disponibilidad == "Disponible").FirstOrDefault();

            if (puesto is null)
                throw new ValidarExceptions($"El puesto con codigo{ticket.PuestoId} no esta disponible");
            else
                ticket.Puesto = puesto;
        }

        private  void ValidarEmpleado(Ticket ticket)
        {
            var empleado = repositorioEmpleado.SeleccionarPorId(ticket.EmpleadoId);

            if (empleado is null)
                throw new ValidarExceptions($"El codigo del empleado {ticket.EmpleadoId} no existe");
        }

        private  void ValidarTicketExistente(Ticket ticket)
        {
            var vehiculoTicket = repositorioTicket.Consultar(x => x.Vehiculo.Placa == ticket.Vehiculo.Placa && x.Estado == "Entrada").FirstOrDefault();

            if (vehiculoTicket is not null)
                throw new ValidarExceptions($"El vehiculo con matricula {ticket.Vehiculo.Placa} ya tiene un ticket pendiente");
        }

        private void ActualizarPuesto(Puesto puesto, Guid puestoid, string estado)
        {
            puesto.Modificar(estado);
            repositorioPuesto.Editar(puesto, puestoid);
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
            ActualizarPuesto(response.Puesto, response.PuestoId, "Disponible");
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

        public List<Ticket> BuscarVarios(DateTime? fecha, string identificacion, string? placa, string? estado)
        {
            List<Ticket> consulta;
            if (identificacion is null)
                consulta = repositorioTicket.Listar();
            else
                consulta = repositorioTicket.BuscarVariosAsync(x => x.Cliente.Identificacion == identificacion);



            if (placa is not null)
                consulta = consulta.Where(x => x.Vehiculo.Placa.Contains(placa)).ToList();

            if (estado is not null)
                consulta = consulta.Where(x => x.Estado == estado).ToList();

            if (fecha is not null)
               consulta = consulta.Where(x=> x.HoraDeEntrada >= fecha).ToList();

            return consulta;

        }
        
        public List<Ticket> BuscarVariosAsync(string identificacion, string placa, string estado, DateTime fecha)
        {
            throw new NotImplementedException();
        }
        public List<Ticket> TicketsEmpleado(Guid empleadoId)
        {
            var resp = repositorioTicket.Consultar(x => x.EmpleadoId == empleadoId);
            if (resp.Count == 0)
                throw new ValidarExceptions("El empleado no tiene tickets atendidos");

            return resp;
        }
    }
}
