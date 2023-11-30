using System;
using Dapper_Web_UI.Dtos.WhoWeAreDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dapper_Web_UI.ViewComponents.HomePage
{
	public class _DefaultWhoWeAreComponentPartial : ViewComponent
	{

        public readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responceMessages = await client.GetAsync("https://localhost:7272/api/WhoWeAre/WhoWeAreDetailList");
            var responceMessages2 = await client.GetAsync("https://localhost:7272/api/WhoWeAreServices/WhoWeAreServicesDetailList");


            if (responceMessages.IsSuccessStatusCode && responceMessages2.IsSuccessStatusCode)
            {
                var jsonData = await responceMessages.Content.ReadAsStringAsync();
                var jsonData2 = await responceMessages2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDTOs>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultWhoWeAreServicesDTOs>>(jsonData2);
                ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.subTitle = value.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.description = value.Select(x => x.Description).FirstOrDefault();
                ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);
            }

            




            return View();
        }
    }
}

