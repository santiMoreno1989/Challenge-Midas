using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services) 
        {
            services.Scan(selector =>
                selector.FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(filter => filter.Where(type => type.Name.EndsWith("Service")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip) // Permite agregar otros servicios con otro tipo de instancia
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                );
        
            return services;
        }
    }
}
