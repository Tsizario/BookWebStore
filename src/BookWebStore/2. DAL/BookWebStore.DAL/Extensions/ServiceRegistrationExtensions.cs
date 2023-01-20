using BookWebStore.DAL.Repositories.CategoryRepository;
using BookWebStore.DAL.Repositories.CoverTypeRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookWebStore.DAL.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseSqlServer(
                    configuration.GetConnectionString("BookWebStoreConnectionString"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICoverTypeRepository, CoverTypeRepository>();

            return services;
        }
    }
}