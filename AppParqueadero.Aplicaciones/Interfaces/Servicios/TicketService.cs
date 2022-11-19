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
    public class TicketService : IServicioBase<Ticket, Guid>
    {
        IRepositorioBase<Ticket, Guid> repositorioTicket;
        IRepositorioBase<Empleado, Guid> repositorioEmpleado;
        IRepositorioBase<Puesto, Guid> repositorioPuesto;
        IRepositorioBase<Tarifa, Guid> repositorioTarifa;
        IRepositorioBase<Cliente, Guid> repositorioCliente;
        IRepositorioBase<Vehiculo, Guid> repositorioVehiculo;
        public TicketService(
            IRepositorioBase<Ticket, Guid> repositorioTicket, 
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
        public void Editar(Ticket entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Guid entidad)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> Listar()
        {
            throw new NotImplementedException();
        }

        public Ticket SeleccionarPorId(Guid entidad)
        {
            throw new NotImplementedException();
        }
    }
}
