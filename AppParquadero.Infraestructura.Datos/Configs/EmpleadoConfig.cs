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
    public class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            builder.HasKey(c => c.EmpleadoId);
            builder.Property(x => x.EmpleadoId)
                .HasDefaultValueSql("NEWID()");
            builder
             .HasMany(v => v.Horarios)
             .WithOne(c => c.Empleado)
             .HasForeignKey(c => c.EmpleadoId);

            builder
            .HasOne(e => e.Usuario)
            .WithOne(us => us.Empleado)
            .HasForeignKey<Usuario>(x=> x.EmpleadoId);
        }
    }
}
