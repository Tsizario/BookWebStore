using AutoMapper;
using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.DTO.CoverType;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.MapperProfiles
{
    public class CoverTypeProfile : Profile
    {
        public CoverTypeProfile()
        {
            CreateMap<CoverType, CoverTypeDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((source, destination, sourceMember) =>
                        sourceMember != null));
        }
    }
}
