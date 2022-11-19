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
    public class TarifaConfig : IEntityTypeConfiguration<Tarifa>
    {
        public void Configure(EntityTypeBuilder<Tarifa> builder)
        {
            builder.ToTable("Tarifa");
            builder.HasKey(c => c.TarifaId);
            builder.Property(x => x.TarifaId)
                .HasDefaultValueSql("NEWID()");
            
        }
    }
}
