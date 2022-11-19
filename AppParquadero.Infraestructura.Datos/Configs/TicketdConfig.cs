using AppParqueadero.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Infraestructura.Datos.Configs
{
    public class TicketdConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticked");
            builder.HasKey(c => c.TickedId);
            builder.Property(x => x.TickedId)
                .HasDefaultValueSql("NEWID()");

            builder
               .HasOne(r => r.Cliente)
               .WithMany(c => c.Tickets)
               .HasForeignKey(r => r.ClienteId);

            builder
             .HasOne(r => r.Puesto)
             .WithMany(p => p.Tickets)
             .HasForeignKey(r => r.PuestoId);

            builder
            .HasOne(r => r.Vehiculo)
            .WithMany(p => p.Tickets)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasConstraintName("Fk_Vehiculo_VehiculoID");




            builder
           .HasOne(r => r.Tarifa)
           .WithMany(p => p.Tickets)
           .HasForeignKey(r => r.TarifaId);

            builder
          .HasOne(r => r.Empleado)
          .WithMany(p => p.Tickets)
          .HasForeignKey(r => r.EmpleadoId);


        }
    }
}
