using AutoMapper;
using BookWebStore.BLL.DTO.Category;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((source, destination, sourceMember) =>
                        sourceMember != null));

            CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }
    }
}
