using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using AppParqueadero.Aplicaciones.Interfaces;
using AppParqueadero.Aplicaciones.Excepciones;
using AppParqueadero.Dominio.Entidades;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class ServicioReserva : IServicioReserva<Reserva, Guid>
    {
        IRepositorioReserva<Reserva, Guid> repositorioReserva;
        IRepositorioBase<Vehiculo, Guid> repositoriovohiculo;
        IRepositorioBase<Cliente, Guid> repositoriocliente;
        IRepositorioBase<Puesto, Guid> repositoriopuesto;
        IRepositorioBase<Tarifa, Guid> repositorioTarifa;

        public ServicioReserva(IRepositorioReserva<Reserva, Guid> _repositorioReserva,
        IRepositorioBase<Vehiculo, Guid> _repositoriovohiculo,
        IRepositorioBase<Cliente, Guid> _repositoriocliente,
        IRepositorioBase<Puesto, Guid> _repositoriopuesto,
        IRepositorioBase<Tarifa, Guid> _repositorioTarifa)
        {
            repositoriocliente = _repositoriocliente;
            repositorioReserva = _repositorioReserva;
            repositoriovohiculo = _repositoriovohiculo;
            repositoriopuesto = _repositoriopuesto;
            repositorioTarifa = _repositorioTarifa;
        }
        public Reserva Agregar(Reserva reserva)
        {
            Reserva respuesta;
            if (reserva is null)
                throw new ValidarExceptions("La reserva es requerida");
            if (!ValidaFecha(reserva.FechaHora))
                throw new ValidarExceptions("La fecha es requerida");
            ValidarPuesto(reserva);
            ValidarReserva(reserva);
            reserva.Modificar("Pendiente");
            ActualizarPuesto(reserva.Puesto, reserva.PuestoId, "Ocupado");
            if (ValidarVehiculoReserva(reserva))
                respuesta = repositorioReserva.Agregar(reserva);
            else
                throw new ValidarExceptions("Vehiculo ya tienes reserva");

            repositorioReserva.GuardarTodosLosCambios();
            return respuesta;
        }

        private void ValidarReserva(Reserva reserva)
        {
            var clienteRespuesta = repositoriocliente.Consultar(x => x.Identificacion == reserva.cliente.Identificacion).FirstOrDefault();
            var respuesta = repositoriovohiculo.Consultar(x => x.Placa == reserva.Vehiculo.Placa).FirstOrDefault();
            if (clienteRespuesta != null)
                reserva.cliente = clienteRespuesta;

            if (respuesta != null)
                reserva.Vehiculo = respuesta;
            else
                reserva.Vehiculo.cliente = reserva.cliente;

        }

        private bool ValidarVehiculoReserva(Reserva reserva)
        {
            var respuestaVehiculo = repositorioReserva.Consultar(x => x.Vehiculo.Placa == reserva.Vehiculo.Placa && x.Estado == "Pendiente").FirstOrDefault();
            return respuestaVehiculo is null;
        }

        private void ValidarPuesto(Reserva reserva)
        {
            var puesto = repositoriopuesto.Consultar(x => x.PuestoId == reserva.PuestoId && x.Disponibilidad == "Disponible").FirstOrDefault();
            if (puesto is null)
                throw new ValidarExceptions("El puesto es requerida preferiblemente disponible");

            reserva.Puesto = puesto;
        }
        public Reserva AnularReserva(Guid entidad)
        {
            var reserva = repositorioReserva.SeleccionarPorId(entidad);
            if (reserva is null)
                throw new ValidarExceptions($"reserva no es valida");

            reserva.Modificar("Cancelada");
            ActualizarPuesto(reserva.Puesto, reserva.PuestoId, "Disponible");
            repositorioReserva.AnularReserva(reserva);
            repositorioReserva.GuardarTodosLosCambios();
            return reserva;
        }

        public void Editar(Reserva entidad, Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> Listar()
        {
            return repositorioReserva.Listar();
        }

        public Reserva SeleccionarPorId(Guid entidad)
        {

            var res = repositorioReserva.SeleccionarPorId(entidad);
            if (res is null)
                throw new ValidarExceptions($"La reserva que busca no existe");

            return res;
        }

        private Boolean ValidaFecha(DateTime fecha)
        {
            return (DateTime.Compare(fecha, DateTime.Now) >= 0) ? fecha.AddMinutes(3) <= DateTime.Now.AddDays(7) : false;

        }

        public async Task<Ticket> GenerarTicket(Ticket entidad, Guid reservaId)
        {

            if (await ValidaReserva(reservaId))
            {
                ValidarReserva(reservaId);
                AsignarTarifa(entidad);
                ActualizarReserva(reservaId);
                entidad.AsingarValores();
                var resp = await repositorioReserva.GenerarTicket(entidad);
                repositorioReserva.GuardarTodosLosCambios();
                return resp;
            }
            else
                throw new ValidarExceptions("La reserva no es correcta");

        }
        private void AsignarTarifa(Ticket ticket)
        {
            var vehiculo = BuscarVehiculo(ticket.VehiculoId);
            var tarifa = repositorioTarifa.Consultar(x => x.Tipo == vehiculo.Tipo).FirstOrDefault();
            if (tarifa is not null)
                ticket.TarifaId = tarifa.TarifaId;
            else
                throw new ValidarExceptions("Tarifa invalida");
        }
        private Vehiculo BuscarVehiculo(Guid idVehiculo)
        {
            var resp = repositoriovohiculo.SeleccionarPorId(idVehiculo);
            if (resp is null)
                throw new ValidarExceptions("El vehiculo no existe");

            return resp;
        }
        private void ActualizarReserva(Guid reservaId)
        {
            var reserva = repositorioReserva.SeleccionarPorId(reservaId);
            if (reserva is not null)
                reserva.Modificar("En uso");
            else
                throw new ValidarExceptions("Error reserva no encontrada");
        }

        public async Task<bool> ValidaReserva(Guid ReservaId)
        {
            return await repositorioReserva.ValidaReserva(ReservaId);
        }
        private void ValidarReserva(Guid guid)
        {
            var reserva = repositorioReserva.Consultar(x => x.ReservaId == guid && x.Estado == "Pendiente").FirstOrDefault();
            if (reserva is null)
                throw new ValidarExceptions("La reserva no es correcta");
        }

        public IEnumerable<Reserva> BuscarReservaCliente(string identificacion)
        {
            var response = repositorioReserva.Consultar(x => x.cliente.Identificacion == identificacion && x.Estado == "Pendiente");
            if (response.Count.Equals(0))
                throw new ValidarExceptions($"El cliente con identificacion {identificacion} no tiene reservas pendiente");

            return response;

        }
        private void ActualizarPuesto(Puesto puesto, Guid puestoid, string estado)
        {
            puesto.Modificar(estado);
            repositoriopuesto.Editar(puesto, puestoid);
        }

        public List<Reserva> BuscarVarios(DateTime? fecha, string identificacion, string? placa, string? estado)
        {
            List<Reserva> consulta;
            if (identificacion is null)
                consulta = repositorioReserva.Listar();
            else
                consulta = repositorioReserva.Consultar(x => x.cliente.Identificacion == identificacion);



            if (placa is not null)
                consulta = consulta.Where(x => x.Vehiculo.Placa.Contains(placa)).ToList();

            if (estado is not null)
                consulta = consulta.Where(x => x.Estado == estado).ToList();

            if (fecha is not null)
                consulta = consulta.Where(x => x.FechaHora >= fecha).ToList();

            return consulta;

        }
    }

}
