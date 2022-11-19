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
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.ClienteId);
            builder.Property(x => x.ClienteId)
                .HasDefaultValueSql("NEWID()");
            builder
             .HasMany(v => v.Vehiculos)
             .WithOne(c => c.cliente)
             .HasForeignKey(c => c.ClienteId);
        }
    }
}
