using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MultiShop.Order.Application.Services;

public static class ServiceRegistirations
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistirations).Assembly));
        
    }
}