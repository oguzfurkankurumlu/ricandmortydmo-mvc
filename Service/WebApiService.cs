using Newtonsoft.Json;
using DTO;
using AutoMapper;
using DMO;
public class WebApiService : IWebApiService
{
    public Helpers _helpers;
    public IWebApiRepository _webApiRepository;
    public WebApiService(IWebApiRepository repository, Helpers helpers)
    {
        _webApiRepository = repository;
        _helpers = helpers;
    }
    public RickAndMortyDTO GetAll()
    {
        // Web API'den gelen DMO verisini alıyoruz
        RickAndMortyDMO returnModel = _webApiRepository.GetAll();

        // Helper sınıfındaki Map metodunu kullanarak DMO verisini DTO'ya dönüştürüyoruz
        var returnDTO = _helpers.Map<RickAndMortyDMO, RickAndMortyDTO>(returnModel);


        // RickAndMortyDTO newReturnModel = new RickAndMortyDTO();
        #region DMO-DTO Mapping El İle
        // newReturnModel.Info = new InfoDTO()
        // {
        //     Count = returnModel.Info.Count,
        //     Next = returnModel.Info.Next,
        //     Pages = returnModel.Info.Pages,
        //     Prev = returnModel.Info.Prev,
        // };

        // newReturnModel.Results = returnModel.Results.Select(s => new DetailDTO()
        // {
        //     Gender = s.Gender,
        //     Id = s.Id,
        //     Image = s.Image,
        //     Name = s.Name,
        //     Type = s.Type,
        //     Status = s.Status,
        //     Species = s.Species,
        //     Location = new LocationDTO()
        //     {
        //         Name = s.Location.Name
        //     }

        // }).ToList();

        #endregion

        // return newReturnModel;
        return returnDTO;
    }

}
public interface IWebApiService
{
    public DTO.RickAndMortyDTO GetAll();
}