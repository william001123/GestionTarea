using Datos.Entidad;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Datos.Config
{
    public class EstadoConfig : IEntityTypeConfiguration<EstadoEnt>
    {
        public void Configure(EntityTypeBuilder<EstadoEnt> builder)
        {
            builder.ToTable(nameof(EstadoEnt));
            builder.HasKey(x => x.codEstado);

            builder
                .HasMany<TareaEnt>(x => x.Tareas)
                .WithOne(oItem => oItem.Estado)
                .HasForeignKey(c => c.codEstado);
        }
    }
}
