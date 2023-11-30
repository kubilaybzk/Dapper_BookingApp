using System;
using Dapper_Web_UI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dapper_Web_UI.ViewComponents.HomePage
{
    // Bu sınıf, bir View Component'i temsil eder.
    public class _DefaultHomePageProductList : ViewComponent
    {
        // HTTP istemcilerini yönetmek için kullanılacak olan HttpClientFactory.
        private readonly IHttpClientFactory _httpClientFactory;

        // Constructor, bağımlılıkları enjekte eder.
        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // View Component'in ana işlevini gerçekleştiren asenkron metot.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // HTTP istemci örneği oluşturulur.
            var client = _httpClientFactory.CreateClient();

            // Belirtilen API endpoint'ine GET isteği gönderilir.
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Product/GetAllProductWithCategory");

            // HTTP isteği başarılı ise devam edilir.
            if (responseMessage.IsSuccessStatusCode)
            {
                // Yanıtın içeriği JSON olarak okunur.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON verisi belirli bir DTO türüne deserialize edilir.
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);

                // View Component'in çağrıldığı view'e veri iletilir.
                return View(values);
            }

            // Eğer HTTP isteği başarısız olursa veya veri alınamazsa, boş bir view döndürülür.
            return View();
        }
    }
}
