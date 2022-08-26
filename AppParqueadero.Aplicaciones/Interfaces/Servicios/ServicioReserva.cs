using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using AppParqueadero.Aplicaciones.Interfaces;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class ServicioReserva : IServicioReserva<Reserva, Guid>
    {
        IRepositorioReserva<Reserva, Guid> repositorioReserva;
        IRepositorioBase< Vehiculo, Guid> repositoriovohiculo;
        IRepositorioBase<Cliente, Guid> repositoriocliente;
        IRepositorioBase<Puesto, Guid> repositoriopuesto;
        public ServicioReserva(IRepositorioReserva<Reserva, Guid> _repositorioReserva,
        IRepositorioBase<Vehiculo, Guid> _repositoriovohiculo,
        IRepositorioBase<Cliente, Guid> _repositoriocliente, IRepositorioBase<Puesto, Guid> _repositoriopuesto)
        {
            repositoriocliente = _repositoriocliente;
            repositorioReserva = _repositorioReserva;
            repositoriovohiculo = _repositoriovohiculo;
            repositoriopuesto = _repositoriopuesto;
        }
        public Reserva Agregar(Reserva reserva)
        {
            try
            {
                if (reserva == null)
                    throw new ArgumentNullException("La reserva es requerida");


                if (ValidaFecha(reserva.FechaHora))
                {
                    if (repositorioReserva.SeleccionarPorId(reserva.Vehiculo.VehiculoId) == null)
                    {
                        if (repositoriopuesto.SeleccionarPorId(reserva.Puesto.PuestoId) == null)
                        {
                            if(repositoriovohiculo.SeleccionarPorId(reserva.Vehiculo.VehiculoId) == null)
                            {
                                repositoriovohiculo.Agregar(reserva.Vehiculo);
                                var respuesta = repositorioReserva.Agregar(reserva);
                                repositorioReserva.GuardarTodosLosCambios();
                                return respuesta;
                            }
                            else
                            {
                                var respuesta = repositorioReserva.Agregar(reserva);
                                repositorioReserva.GuardarTodosLosCambios();
                                return respuesta;

                            }
                        }
                        else
                        {
                            throw new ArgumentNullException("el puesto es requerido");
                        }

                    }
                    else
                    {
                        throw new ArgumentNullException("Vehiculo ya tienes reserva");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Fecha invalida");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AnularReserva(Reserva entidad)
        {
            try
            {
                var reserva = repositorioReserva.SeleccionarPorId(entidad.ReservaId);

                if (reserva != null && reserva.Estado != "En uso" && reserva.Estado != "Cancelada")
                {
                    var puesto = repositoriopuesto.SeleccionarPorId(entidad.PuestoId);
                    puesto.Disponibilidad = "Disponible";
                    reserva.Estado = "Cancelada";
                    repositorioReserva.Editar(reserva);
                    repositoriopuesto.Editar(puesto);
                    repositorioReserva.GuardarTodosLosCambios();
                }
                else
                {
                    throw new ArgumentNullException("No es posible cancelar la reserva");
                }


            }
            catch (Exception e)
            {
                throw new ArgumentNullException(e.Message);
            }
        }

        public void Editar(Reserva entidad)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> Listar()
        {
            return repositorioReserva.Listar();
        }

        public Reserva SeleccionarPorId(Guid entidad)
        {
           return repositorioReserva.SeleccionarPorId(entidad);
        }

        private Boolean ValidaFecha(DateTime fecha)
        {
            if (DateTime.Compare(fecha, DateTime.Now.AddSeconds(-30)) >= 0)
            {
                var fecha1 = DateTime.Now.AddDays(7);
                return fecha.AddMinutes(3) <= fecha1;
            }
            return false;

        }
    }
}
