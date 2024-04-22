using Datos.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Config
{
    public class TareaConfig : IEntityTypeConfiguration<TareaEnt>
    {
        public void Configure(EntityTypeBuilder<TareaEnt> builder)
        {
            builder.ToTable(nameof(TareaEnt));
            builder.HasKey(e => e.tareaID);
        }
    }
}
