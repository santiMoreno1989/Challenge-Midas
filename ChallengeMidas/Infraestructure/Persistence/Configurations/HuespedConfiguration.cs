using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class HuespedConfiguration : IEntityTypeConfiguration<Huesped>
    {
        public void Configure(EntityTypeBuilder<Huesped> builder)
        {
            builder.Property(h => h.Nombre).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(h => h.Apellido).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(h => h.Email).HasColumnType("VARCHAR(100)").IsRequired();

            builder.HasOne(h => h.Habitacion)
                    .WithMany(h => h.Huespedes)
                    .HasForeignKey(h => h.HabitacionId)
                    .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(h => h.Reserva)
                    .WithOne(h => h.Huesped)
                    .HasForeignKey<Huesped>(h => h.ReservaId)
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
