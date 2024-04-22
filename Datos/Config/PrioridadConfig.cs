using Datos.Entidad;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Datos.Config
{
    public class PrioridadConfig : IEntityTypeConfiguration<PrioridadEnt>
    {
        public void Configure(EntityTypeBuilder<PrioridadEnt> builder)
        {
            builder.ToTable(nameof(PrioridadEnt));
            builder.HasKey(x => x.codPrioridad);

            builder
                .HasMany<TareaEnt>(x => x.Tareas)
                .WithOne(oItem => oItem.Prioridad)
                .HasForeignKey(c => c.codPrioridad);
        }
    }
}
