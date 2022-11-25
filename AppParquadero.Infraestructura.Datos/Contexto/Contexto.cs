using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AppParqueadero.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppParquadero.Infraestructura.Datos.Configs;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Infraestructura.Datos.Configs;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppParquadero.Infraestructura.Datos.Contexto
{
    public class ParqueaderoContexto:DbContext
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> reservas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        [NotMapped]
        public DbSet<Estadistica> Estadisticas { get; set; }
        [NotMapped]
        public DbSet<VehiculosMasUsados> vehiculosMasUsados { get; set; }
        [NotMapped]
        public DbSet<TotalGeneradoCadaMes> TotalGenerados { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = VICTOR; Database = ParqueaderoBDO; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new ReservaConfig());
            modelBuilder.ApplyConfiguration(new PuestoConfig());
            modelBuilder.ApplyConfiguration(new VehiculoConfig());
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
            modelBuilder.ApplyConfiguration(new HorarioConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new TarifaConfig());
            modelBuilder.ApplyConfiguration(new TicketdConfig());


            modelBuilder.Entity<Puesto>().HasData(DataSeed.DataPuestos());
            modelBuilder.Entity<Tarifa>().HasData(DataSeed.DataTarifas());


        }


    }
}
