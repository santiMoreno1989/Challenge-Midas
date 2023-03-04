using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.Property(r => r.FechaEntrada).HasColumnType("datetime2");
            builder.Property(r => r.FechaSalida).HasColumnType("datetime2");

            builder.HasOne(r => r.Habitacion)
                .WithMany(h => h.Reservas)
                .HasForeignKey(r => r.HabitacionId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
