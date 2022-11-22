using AppParqueadero.Aplicaciones.Excepciones;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class TarifaService : IServicioBase<Tarifa, Guid>
    {
        private readonly IRepositorioBase<Tarifa, Guid> repositorioTarifa;
        public TarifaService(IRepositorioBase<Tarifa, Guid> repositorioTarifa_)
        {
            repositorioTarifa = repositorioTarifa_;
        }
        public Tarifa Agregar(Tarifa entidad)
        {
            Tarifa tarifa;
            if (ValidarTarifa(entidad))
                tarifa = repositorioTarifa.Agregar(entidad);
            else
                throw new ValidarExceptions($"La tarifa de tipo {entidad.Tipo} ya exite");


            repositorioTarifa.GuardarTodosLosCambios();
            return tarifa;
        }
        private bool ValidarTarifa(Tarifa entidad)
        {
            var tarifa = repositorioTarifa.Consultar(x => x.Tipo == entidad.Tipo).FirstOrDefault();
            return tarifa is null;
        }
        public void Editar(Tarifa entidad, Guid id)
        {
            var response = repositorioTarifa.SeleccionarPorId(id);
            if (response is null)
                throw new ValidarExceptions($"La tarifa {entidad.Tipo} no exite");
            response.Actualizar(entidad.Valor);
            repositorioTarifa.Editar(response,id);
            repositorioTarifa.GuardarTodosLosCambios();

        }
       

        public void Eliminar(Guid entidad)
        {
            var response = repositorioTarifa.SeleccionarPorId(entidad);
            if (response is not null)
                repositorioTarifa.Eliminar(entidad);
            else
                throw new ValidarExceptions($"la tarifa que desea eliminar no existe");

            repositorioTarifa.GuardarTodosLosCambios();
        }

        public List<Tarifa> Listar()
        {
            return repositorioTarifa.Listar();
        }

        public Tarifa SeleccionarPorId(Guid entidad)
        {
            var res = repositorioTarifa.SeleccionarPorId(entidad);
            if (res is null)
                throw new ValidarExceptions($"La tarifa que busca no existe");

            return res;
        }
    }
}
