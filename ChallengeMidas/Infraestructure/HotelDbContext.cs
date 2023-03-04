using Infraestructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestructure
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.RecepcionistaSeed();
            builder.HabitacionSeed();
            base.OnModelCreating(builder);
        }
    }
}
