using AutoMapper;
using BookWebStore.BLL.DTO.Category;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((source, destination, sourceMember) =>
                        sourceMember != null));
        }
    }
}
