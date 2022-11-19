using AppParqueadero.Dominio;
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
    public class HorarioConfig : IEntityTypeConfiguration<Horario>
    {
      
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.ToTable("Horario");
            builder.HasKey(c => c.HorarioId);
            builder.Property(x => x.HorarioId)
                .HasDefaultValueSql("NEWID()");

            builder
              .HasOne(c => c.Empleado)
              .WithMany(v => v.Horarios)
              .HasForeignKey(c => c.EmpleadoId);

        }
    }
}
