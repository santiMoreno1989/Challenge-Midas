using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructureLayer(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<HotelDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HotelConnection"), optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(typeof(HotelDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.Scan(selector =>
                selector.FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(filter=> filter.Where(type=> type.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                    );

            return services;
        }
    }
}
