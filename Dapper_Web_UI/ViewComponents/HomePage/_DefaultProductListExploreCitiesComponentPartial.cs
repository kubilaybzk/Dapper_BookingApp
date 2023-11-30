using System;
using Dapper_Web_Api.DTOs.PopularLocation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dapper_Web_UI.ViewComponents.HomePage
{
	public class _DefaultProductListExploreCitiesComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultProductListExploreCitiesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            string api = "https://localhost:7272/api/PopularLocations/PopularLocationList";
            var responceMessages = await client.GetAsync(api);

            if (responceMessages.IsSuccessStatusCode)
            {
                var jsondata = await responceMessages.Content.ReadAsStringAsync();
                var value =  JsonConvert.DeserializeObject<List<ResultPopularLocationDTOs>>(jsondata);

                return View(value);

            }

            return View();
        }
    }
}

