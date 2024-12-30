using Newtonsoft.Json;
using DTO;
using AutoMapper;
using DMO;
public class WebApiService : IWebApiService
{

    public IWebApiRepository _webApiRepository;
    
    public WebApiService(IWebApiRepository repository )
    {
        _webApiRepository = repository;
        
    }
    public RickAndMortyDTO GetAll()
    {
        RickAndMortyDMO returnModel = _webApiRepository.GetAll();


        RickAndMortyDTO newReturnModel = new RickAndMortyDTO();

        #region DMO-DTO Mapping El İle
        newReturnModel.Info = new InfoDTO()
        {
            Count = returnModel.Info.Count,
            Next = returnModel.Info.Next,
            Pages = returnModel.Info.Pages,
            Prev = returnModel.Info.Prev,
        };

        newReturnModel.Results = returnModel.Results.Select(s => new DetailDTO()
        {
            Gender = s.Gender,
            Id = s.Id,
            Image = s.Image,
            Name = s.Name,
            Type = s.Type,
            Status = s.Status,
            Species = s.Species,
            Location = new LocationDTO()
            {
                Name = s.Location.Name
            }

        }).ToList();

        #endregion

        return newReturnModel;
    }

}
public interface IWebApiService
{
    public DTO.RickAndMortyDTO GetAll();
}