// Web dünyasında, Repository katmanı, her zaman bir veriye erişmek için kullanılır

// veri sadece veri tabanı değildir. Başka uygulamalara erişmek ve onlardan veri çekmek ve veri göndermek için her zaman repository katmanı kullanılır

// Repository Katmanı, her zaman ama her zaman veri ile iletişimdedir.

// bu veri, başka bir web sitesinden gelen veri olabilir
// bu veri, bir veri tabanına bağlandıktan sonra çekilen veri olabilir
// bu veri dosya sistemindeki bir dosyadan okuma işlemi yada yazma işlemi olabilir
// bir cihaza bağlantı, cihazdan veri alma verme olabilr
using DMO;
using Newtonsoft.Json;
using RestSharp;

public class WebApiRepository:IWebApiRepository
{
    public string GetAll()
    {
        // Rick and morty sitesine RestSharp kullanarak istek atalım!!
        var options = new RestClientOptions("https://rickandmortyapi.com/api/");
        var client = new RestClient(options);
        var request = new RestRequest("character");
        
        //get yapa post oldugunu burdan anlayacagız.kendımız verdık bunu method.get i 
        request.Method =  Method.Get;
        // The cancellation token comes from the caller. You can still make a call without it.
        var timeline =  client.Get(request);

        
         return timeline.Content;

    }
}
public interface IWebApiRepository
{
    public string GetAll();
}