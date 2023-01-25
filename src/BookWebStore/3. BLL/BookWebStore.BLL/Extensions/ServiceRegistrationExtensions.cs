using AutoMapper;
using BookWebStore.BLL.MapperProfiles;
using BookWebStore.BLL.Services.CategoryService;
using BookWebStore.BLL.Services.ProductService;
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
                m.AddProfile<CoverTypeProfile>();
                m.AddProfile<ProductProfile>();
            });

            services.AddSingleton(s => mapperConfig.CreateMapper());

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICoverTypeService, CoverTypeService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}