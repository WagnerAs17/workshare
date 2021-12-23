using Microsoft.Extensions.DependencyInjection;
using workshare.clientes.data.Context;
using workshare.clientes.data.Repositories;
using workshare.clientes.domain.Models.Repositories;

namespace workshares.clientes.api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDependency(this IServiceCollection services)
        {
            Repository(services);

            return services;
        }

        private static void Repository(IServiceCollection services)
        {
            services.AddScoped<ClienteContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
