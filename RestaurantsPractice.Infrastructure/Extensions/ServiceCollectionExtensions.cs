using Microsoft.Extensions.DependencyInjection;
using RestaurantsPractice.Infrastructure.Persistence;

namespace RestaurantsPractice.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<RestaurantsDbContext>();
        }
    }
}
