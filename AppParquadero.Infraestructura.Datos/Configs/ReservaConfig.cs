using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppParqueadero.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppParquadero.Infraestructura.Datos.Configs
{
    public class ReservaConfig : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(c => c.ReservaId);
            builder.Property(x => x.ReservaId)
             .HasDefaultValueSql("NEWID()");

            builder
                .HasOne(r => r.cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId);

            builder
                .HasOne(r => r.Vehiculo)
                .WithMany(v => v.Reservas)
                .HasForeignKey(r => r.VehiculoId)
                .OnDelete(DeleteBehavior.ClientCascade); 

            builder
                .HasOne(r => r.Puesto)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.PuestoId);
        }
    }
}
