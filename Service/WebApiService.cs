using DMO;
using Newtonsoft.Json;
public class WebApiService : IWebApiService
{

    public IWebApiRepository _webApiRepository;
  
    public WebApiService(IWebApiRepository repository)
    {
        _webApiRepository = repository;
     
    }
    public RickAndMortyDMO GetAll()
    {

      string Jsonstring = _webApiRepository.GetAll();
      RickAndMortyDMO resultData = JsonConvert.DeserializeObject<RickAndMortyDMO>(Jsonstring);
      return resultData;
    }

}
public interface IWebApiService
{
    public RickAndMortyDMO GetAll();
}