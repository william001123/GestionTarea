using Datos.Entidad;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Config
{
    public class PersonaConfig : IEntityTypeConfiguration<PersonaEnt>
    {
        public void Configure(EntityTypeBuilder<PersonaEnt> builder)
        {
            builder.ToTable(nameof(PersonaEnt));
            builder.HasKey(x => x.usuario);

            builder
                .HasMany<TareaEnt>(x => x.Tareas)
                .WithOne(oItem => oItem.Persona)
                .HasForeignKey(c => c.personaAsignada);
        }
    }
}
