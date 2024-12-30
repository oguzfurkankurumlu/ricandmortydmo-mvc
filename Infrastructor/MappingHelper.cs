

using AutoMapper;
using DMO;
using DTO;


public class Helpers
{
    private readonly IMapper _mapper;

    // AutoMapper'ı constructor üzerinden alıyoruz
    public Helpers(IMapper mapper)
    {
        _mapper = mapper;
    }

    // Genel mapleme metodunu güncelledik
    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TDestination>(source);
    }






    //calısmadı burası hata verdı
    // public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    // {

    //     var config = new MapperConfiguration(cfg =>
    //     {
    //         cfg.CreateMap<TSource, TDestination>();
    //     });

    //     Mapper mapper = new Mapper(config);
    //     return mapper.Map<TSource, TDestination>(source, destination);


    // public RickAndMortyDTO Map(RickAndMortyDMO source)
    // {
    //     var config = new MapperConfiguration(s =>
    //     {
    //         s.CreateMap<Info, InfoDTO>();
    //         s.CreateMap<Detail, DetailDTO>();
    //         s.CreateMap<Location, LocationDTO>();
    //         s.CreateMap<RickAndMortyDMO, RickAndMortyDTO>();
    //     });
    //     Mapper mapper = new Mapper(config);
    //     return mapper.Map<RickAndMortyDMO ,RickAndMortyDTO>(source);
    // }


    // public TDestination Map<TSource, TDestination>(TSource source)
    // {
    //     // Implement the mapping logic here
    //     // For example, using AutoMapper:
    //     var config = new MapperConfiguration(cfg =>
    //     cfg.CreateMap<TSource, TDestination>());


    //     var mapper = config.CreateMapper();
    //     return mapper.Map<TDestination>(source);
    // }



}
