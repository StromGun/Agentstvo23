using Agentstvo23.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Agentstvo23.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IBuildingCount, BuildingCountService>()
            ;
    }
}
