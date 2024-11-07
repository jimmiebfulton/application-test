using CustomerService.APIs;

namespace CustomerService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAddressesService, AddressesService>();
        services.AddScoped<ICustomersService, CustomersService>();
    }
}
