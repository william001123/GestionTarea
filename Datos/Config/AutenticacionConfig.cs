using Datos.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Config
{
    public class AutenticacionConfig : IEntityTypeConfiguration<AutenticacionEnt>
    {
        public void Configure(EntityTypeBuilder<AutenticacionEnt> builder)
        {
            builder.ToTable(nameof(AutenticacionEnt));
            builder.HasKey(x => x.id);

            builder
                .HasOne<PersonaEnt>(oRow => oRow.Persona)
                .WithOne(oItem => oItem.Autenticacion)
                .HasForeignKey<AutenticacionEnt>(c => c.usuario);
        }
    }
}
