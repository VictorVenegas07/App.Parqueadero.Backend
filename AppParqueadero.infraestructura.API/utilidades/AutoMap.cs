using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models;
using AutoMapper;

namespace AppParqueadero.infraestructura.API.utilidades
{
    public class AutoMap:Profile
    {
        public AutoMap()
        {
            CreateMap<ReservaModel, Reserva>();
            CreateMap<ClienteModels, Cliente>();
            CreateMap<VehiculoModels, Vehiculo>();
            CreateMap<TicketModels, Ticket>();

        }
    }
}
