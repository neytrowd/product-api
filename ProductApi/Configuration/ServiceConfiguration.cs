using ProductApi.Services.Product;

namespace ProductApi.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}