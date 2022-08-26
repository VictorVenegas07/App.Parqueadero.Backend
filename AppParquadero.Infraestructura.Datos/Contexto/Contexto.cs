using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AppParqueadero.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppParquadero.Infraestructura.Datos.Configs;

namespace AppParquadero.Infraestructura.Datos.Contexto
{
    public class ParqueaderoContexto:DbContext
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LAPTOP - 1I2RKO51\\SQLEXPRESS; Database = ParqueaderoBD; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new ReservaConfig());
            modelBuilder.ApplyConfiguration(new PuestoConfig());
            modelBuilder.ApplyConfiguration(new VehiculoConfig());
        }


    }
}
