using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models.Cliente;
using AppParqueadero.infraestructura.API.Models.Empleado;
using AppParqueadero.infraestructura.API.Models.Puesto;
using AppParqueadero.infraestructura.API.Models.Reserva;
using AppParqueadero.infraestructura.API.Models.Tarifa;
using AppParqueadero.infraestructura.API.Models.Ticket;
using AppParqueadero.infraestructura.API.Models.Usuario;
using AppParqueadero.infraestructura.API.Models.Vehiculo;
using AutoMapper;
using System;

namespace AppParqueadero.infraestructura.API.utilidades
{
    public class AutoMap:Profile
    {
        public AutoMap()
        {
            #region "Modelos de reserva"
            //Modelo de entrada reserva
            CreateMap<ReservaModel, Reserva>();
            //modelo de salida reserva 
            CreateMap<Reserva, ViewReserva>();
            CreateMap<TicketReserva, Ticket>();


            #endregion
            #region "Modelos de cliente"
            //Modelo de entrada cliente
            CreateMap<ClienteModels, Cliente>();
            //Modelo de salida cliente
            CreateMap<Cliente, ViewCliente>();

            #endregion
            #region "Modelos de Vehiculo"
            //Modelo de entrada Vehiculo
            CreateMap<VehiculoModels, Vehiculo>();
            CreateMap<VehiculoInput, Vehiculo>();

            //Modelo de salida Vehiculo
            CreateMap<Vehiculo, ViewVehiculo>();


            #endregion
            #region "Modelo de tarifa"
            //modelo de entrada tarifa
            CreateMap<TarifaModels, Tarifa>();
            CreateMap<Tarifa, TarifaModels>();

            #endregion
            #region "Modelos de Ticket"
            //Modelo de entrada ticket
            CreateMap<TicketModels, Ticket>();
            //modelo de salida ticket
            CreateMap<Ticket, ViewTicketd>();
            #endregion

            #region "Modelos de Puesto"
            //Modelo de entrada Puesto
            CreateMap<InputPuesto, Puesto>();
            //modelo de salida Puesto
            CreateMap<Puesto, ViewPuesto>();
            #endregion

            #region "Modelos de Empleado"
            //Modelo de entrada empleado
            CreateMap<EmpleadoInput, Empleado>();
            CreateMap<UpdateEmpleado, Empleado>();
            //modelo de salida empleado
            CreateMap<Empleado, ViewEmpleado>();
            #endregion


            #region "Modelos de Usuario"
            //Modelo de entrada Usuario
            CreateMap<UsuarioInput, Usuario>();
            //modelo de salida Usuario
            CreateMap<Usuario, UsuarioLog>();

            #endregion

        }
    }
}
