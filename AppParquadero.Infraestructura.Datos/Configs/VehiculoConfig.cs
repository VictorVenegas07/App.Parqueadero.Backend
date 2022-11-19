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
    public class VehiculoConfig : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
           builder.ToTable("Vehiculo");
            builder.HasKey(c => c.VehiculoId);
            builder.Property(x => x.VehiculoId)
             .HasDefaultValueSql("NEWID()");

            builder
               .HasOne(c => c.cliente)
               .WithMany(v => v.Vehiculos)
               .HasForeignKey(c => c.ClienteId);
        }
    }
}
