using Agentstvo23.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agentstvo23.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<RealEstateDB>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));
            });
    }
}
