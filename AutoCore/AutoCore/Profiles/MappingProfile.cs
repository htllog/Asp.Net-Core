using AutoCore.Dtos;
using AutoMapper;

namespace AutoCore.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SourceClass, DestinationClass>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
    }
}