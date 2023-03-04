using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.SeedData
{
    public static class RecepcionistaSeedData
    {
        public static void RecepcionistaSeed(this ModelBuilder builder)
        {
            builder.Entity<Recepcionista>().HasData(
                new Recepcionista
                {
                    Id = 1,
                    Nombre = "Santiago",
                    Apellido = "Moreno",
                    Legajo = 13417
                },
                new Recepcionista
                {
                    Id = 2,
                    Nombre = "Gala",
                    Apellido = "Iglesias",
                    Legajo = 13419
                },
                new Recepcionista 
                {
                    Id= 3,
                    Nombre="Osvaldo",
                    Apellido="Olivier",
                    Legajo=13717
                }
                );
        }
    }
}
