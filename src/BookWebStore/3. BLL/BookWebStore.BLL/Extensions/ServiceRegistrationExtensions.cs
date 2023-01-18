using AutoMapper;
using BookWebStore.BLL.MapperProfiles;
using BookWebStore.BLL.Services.CategoryService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookWebStore.BLL.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<CategoryProfile>();
            });

            services.AddSingleton(s => mapperConfig.CreateMapper());

            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}