ASP.NET MVC - Service ve Repository Yapısı
Bu proje, ASP.NET MVC uygulamasında Service ve Repository katmanlarını içeren bir mimariyi kullanmaktadır. Her sınıf, işlevselliğini bir interface aracılığıyla sunar ve constructor injection yöntemi ile bağımlılıklar yönetilir.

1. Repository Katmanı
Repository katmanı, veri erişim işlemleriyle ilgilenen sınıfları içerir. Bu katman, veri kaynaklarıyla iletişimi sağlar. Her repository sınıfı, ilgili interface tarafından tanımlanan metotları implement eder.


2. Service Katmanı
Service katmanı, iş mantığını uygulayan sınıfları içerir ve genellikle controller'lar ile repository'ler arasındaki bağlayıcıdır. Service katmanı, repository'den aldığı veriler üzerinde iş mantığı uygulayarak, bu verileri controller'a sunar.

2.1. IService Interface
Service katmanında yer alan interface, iş mantığını tanımlar ve repository'den alınan verilerin işlenmesi gereken metotları belirtir.

3. Dependency Injection (DI) - Service ve Repository Bağımlılıkları
Service ve Repository sınıflarının bağımlılıkları, Program.cs dosyasında DI konteynerine kaydedilir. Bu sayede her iki katman da constructor injection ile bağımsız olarak yönetilir.

4. Uygulama Çapında Kullanım
Repository: Veri erişim işlemleri için kullanılır. API çağrıları, veritabanı işlemleri vb. işlemler burada yapılır.
Service: İş mantığı burada uygulanır. Controller'lar ve Repository'ler arasındaki iş akışını yönetir.

5. Özet
Repository katmanı, veri kaynaklarına erişim sağlar ve bu erişim için bir interface ile soyutlanır.
Service katmanı, iş mantığını içerir ve veri erişim işlemleri için repository sınıflarını kullanır.
Her iki katman da constructor injection yöntemiyle bağımsız bir şekilde yönetilir ve uygulama bağımlılıklarından soyutlanır.
Bu yapıyı, büyük ve sürdürülebilir projeler için temiz ve bakımı kolay bir mimari olarak kullanabilirsiniz.




Service, Repository klasorlerı açtım
------------------------------------------------------------------------------------------------------------------------------------

Repository altına WebApiRepository.cs tanımladım


    public interface IwebApiReporsitory
    {

    }


    public class WebApiRpository
    {

    }
Her sınıfta bir interface olmalı contrusctor ınjectıon , newleme yapmıyoruz.

------------------------------------------------------------------------------------------------------------------------------------

DMO, DTO ve ViewModel KLASORLERINI OLUSUTRUDK Models ICINDE 

Web dünyasında, Repository katmanı, her zaman bir veriye erişmek için kullanılır
Veri sadece veri tabanı değildir. Başka uygulamalara erişmek ve onlardan veri çekmek ve veri göndermek için her zaman repository katmanı kullanılır.
Repository Katmanı, her zaman ama her zaman veri ile iletişimdedir.
    bu veri, başka bir web sitesinden gelen veri olabilir
    bu veri, bir veri tabanına bağlandıktan sonra çekilen veri olabilir
    bu veri dosya sistemindeki bir dosyadan okuma işlemi yada yazma işlemi olabilir
    bir cihaza bağlantı, cihazdan veri alma verme olabilir

------------------------------------------------------------------------------------------------------------------------------------
rickandmorty apiye gidtitk 
https://rickandmortyapi.com/documentation/#get-all-characters

DMO ICINDE
RİckAndMortyDMO.cs Olusturdum

Class tanımladım
public class RickAndMortyDMO
{

}

sonrasında api den ısıme yaraynları bıraktım 

Info kısmı ıcın class actım 
    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public int? Prev { get; set; }
    }

result ıcınbır class tanımladım 
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public Location Location { get; set; }
    }

location bılgısını almak ıcın bır class tanımladım 

    public class Location
    {
        public string Name { get; set; }
    }
name bılgısını aldım sadece locatıon dan 


Detaıl classına 
    public string Image { get; set; }
     public Location Location { get; set; }
bu ıkısını ekledım en alta 

RIckandMorty classına gerı geldım.(ÇOK RESULT OLDUGU ICIN LIST TIPINDE ALDIM)
public class RickAndMorty
    {

        public List<Detail> Results { get; set; }
        public Info Info { get; set; }
    }

------------------------------------------------------------------------------------------------------------------------------------
RestSharp paketi, .NET projelerinde HTTP istemci işlemlerini kolaylaştırmak için kullanılan popüler bir .NET kütüphanesidir. Bu paket, özellikle RESTful API'lerle iletişim kurmayı kolaylaştırır ve HTTP isteklerini (GET, POST, PUT, DELETE vb.) hızlı bir şekilde yapmanıza olanak tanır.

REST SHARP PAKETINİ IINDIRDIM.
dotnet add package RestSharp --version 112.1.1-alpha.0.4

------------------------------------------------------------------------------------------------------------------------------------

Webapireposioye  GERİ GİTTİM 

    
    public class WebApiRepository:IWebApiRepository
    {
        public void GetAll()
        {
            // Rick and morty sitesine RestSharp kullanarak istek atalım!!
            
            RESTSHARP SITESINEN KULLANIMI ALDIK
                var options = new RestClientOptions("https://rickandmortyapi.com/api/");
                var client = new RestClient(options);
                var request = new RestRequest("character");

                //get yapa post oldugunu burdan anlayacagız.kendımız verdık bunu method.get i 
                request.Method =  Method.Get;
                // The cancellation token comes from the caller. You can still make a call without it.
                var timeline =  client.Get(request);
        }
    }


    public interface IWebApiRepository
        {
            public void GetAll();
        }


------------------------------------------------------------------------------------------------------------------------------------
SERVİCE GİTTİK
WEBAPİSERVİCE.CS ACTIK

public interface IWebApiService
{
}

public class WebApiService : IWebApiService
{
    public IWebApiRepository _webApiRepository;
     public WebApiService(IWebApiRepository repository)
    {
        _webApiRepository = repository;
    }
}

olusturduk, weapiservice classına repositoryi ekledık 

bunu ayınısınıda. service ı controllerden cagırmam lazım
HOMECONTROLLERA GIDIP 

    public class HomeController : Controller
    {   
        public IWebApiService _webApiService { get; set; }
        public HomeController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
    }
------------------------------------------------------------------------------------------------------------------------------------
program.cs e gıdıp bagımlılıkları ekleıdm 
// bağımlılıkları ekleyelim!!
builder.Services.AddScoped<IWebApiRepository,WebApiRepository>();
builder.Services.AddScoped<IWebApiService,WebApiService>();
---------------------------------------------------------------------------------------------------------------------------

WebApiService e gittim 

    public WebApiService(IWebApiRepository repository)
    {
        _webApiRepository = repository;
     
    }
    public void GetAll()
    {

      _webApiRepository.GetAll();
    }

    get all ıle cagırdım. 

Home controller ındexe gitim 
     public IActionResult Index()
    {
        _webApiService.GetAll();
        return View();
    }
cagırdım.
---------------------------------------------------------------------------------------------------------------------------
JSON VERILER GELDI CAGIRDIKTAN SONRA. JSON VERILERI C# DOSYASINA CEVIRMEK ISTIYECEGIM C# DA KULLANABILMEK ICIN
newtonsoft.json paketını ındırdım.
jsonlarımı ıstedıgım toıpe cevırır 
veye bır tipi jsona cevırır.
dotnet add package Newtonsoft.Json --version 13.0.3

---------------------------------------------------------------------------------------------------------------------------

REPOSİTORRYE GERI DONDUM 

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

                JsonConvert.DeserializeObject<DMO.RickAndMorty>(timeline.Content);
                return timeline.Content;

                }
        }
        public interface IWebApiRepository
        {
            public string GetAll();
        }

---------------------------------------------------------------------------------------------------------------------------
      
webapi service e geri döndüm 

     public void GetAll()
    {
      string Jsonstring = _webApiRepository.GetAll();
      RickAndMortyDMO resultData = JsonConvert.DeserializeObject<RickAndMortyDMO>(Jsonstring);
    }
verilerin geldıgınıgordukten sonra gerı donusu RickAndMortyDMO oalrak aldık

-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
Automapper kurulumu
dotnet add package AutoMapper --version 13.0.1

Webapi repository ıcıne 