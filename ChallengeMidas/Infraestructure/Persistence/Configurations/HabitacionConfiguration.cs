using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.Property(h => h.TipoHabitacionEnum).IsRequired();
            builder.Property(h=> h.Precio).HasColumnType("decimal").HasPrecision(18,3);
        }
    }
}
