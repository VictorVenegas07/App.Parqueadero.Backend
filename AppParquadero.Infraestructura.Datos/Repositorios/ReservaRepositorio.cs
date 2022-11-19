﻿using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Infraestructura.Datos.Repositorios
{
    public class ReservaRepositorio : IRepositorioReserva<Reserva, Guid>
    {
        ParqueaderoContexto contexto;
        public ReservaRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Reserva Agregar(Reserva entidad)
        {
            contexto.reservas.Add(entidad);
            return entidad;
        }

        public void AnularReserva(Reserva entidad)
        {
            contexto.reservas.Update(entidad);
            contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Reserva> Consultar(Func<Reserva, bool> expression = null)
        {
            if (expression != null)
                return contexto.reservas.Where(expression).ToList();
            return contexto.reservas.ToList();
        }

        public void Editar(Reserva entidad)
        {
            contexto.reservas.Update(entidad);
            contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarTodosLosCambios()
        {
            try
            {
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al tratar de guardar los datos: "+ex.Message);
            }
        }

        public List<Reserva> Listar()
        {
            return contexto.reservas.ToList();
        }

        public Reserva SeleccionarPorId(Guid entidad)
        {
            return contexto.reservas.Where(c => c.ReservaId == entidad)
                 .OrderBy(c => c.ReservaId)
                 .FirstOrDefault();
        }
    }
}