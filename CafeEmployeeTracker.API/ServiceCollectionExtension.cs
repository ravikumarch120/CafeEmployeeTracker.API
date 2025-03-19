using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CafeEmployeeTracker.Application;
using CafeEmployeeTracker.Infrstructure;

namespace CafeEmployeeTracker.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAPIServiceCollectionExtension(this IServiceCollection services, IHostEnvironment hostEnvironment)
        {
            services.AddControllers();
            //services.AddApplicationServices(); // Assuming the correct method name is AddApplicationServices
            //services.AddInfrastructureServices((IConfiguration)hostEnvironment);
            return services;
        }
    }
}
