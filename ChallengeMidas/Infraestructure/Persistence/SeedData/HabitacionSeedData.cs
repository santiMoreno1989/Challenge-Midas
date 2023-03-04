using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.SeedData
{
    public static class HabitacionSeedData
    {
        public static  void HabitacionSeed(this ModelBuilder builder) 
        {
            builder.Entity<Habitacion>().HasData(
                new Habitacion 
                {
                    Id=1,
                    TipoHabitacionEnum=(int)E_Habitacion.DobleClasica,
                    Capacidad=2,
                    Precio=10.500m
                },
                new Habitacion 
                {
                    Id=2,
                    TipoHabitacionEnum=(int)E_Habitacion.TripleClasica,
                    Capacidad=3,
                    Precio=14.900m,
                },
                new Habitacion 
                {
                    Id=3,
                    TipoHabitacionEnum=(int)E_Habitacion.HabitacionDeluxe,
                    Capacidad=2,
                    Precio=18.900m
                },
                new Habitacion 
                {
                    Id=4,
                    TipoHabitacionEnum=(int)E_Habitacion.Suite,
                    Capacidad=3,
                    Precio=26.500m
                });
        }
    }
}
