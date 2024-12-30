using AutoMapper;
using DMO;  // Data Model Objects
using DTO;  // Data Transfer Objects

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Info, InfoDTO>();
        CreateMap<Location, LocationDTO>();
        CreateMap<Detail, DetailDTO>();
        CreateMap<RickAndMortyDMO, RickAndMortyDTO>();
    }
}
