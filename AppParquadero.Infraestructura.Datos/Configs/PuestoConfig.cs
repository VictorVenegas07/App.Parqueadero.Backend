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
    public class PuestoConfig : IEntityTypeConfiguration<Puesto>
    {
        public void Configure(EntityTypeBuilder<Puesto> builder)
        {
            builder.ToTable("Puesto");
            builder.HasKey(c => c.PuestoId);
            builder.Property(x => x.PuestoId)
             .HasDefaultValueSql("NEWID()");
        }
    }
}
