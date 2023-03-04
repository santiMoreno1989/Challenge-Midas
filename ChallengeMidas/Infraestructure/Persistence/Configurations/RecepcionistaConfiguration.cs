using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class RecepcionistaConfiguration : IEntityTypeConfiguration<Recepcionista>
    {
        public void Configure(EntityTypeBuilder<Recepcionista> builder)
        {
            builder.Property(r => r.Nombre).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(r => r.Apellido).HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}
