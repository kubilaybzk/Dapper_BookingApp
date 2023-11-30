using System;
using Dapper_Web_Api.DTOs.BottomGrid;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dapper_Web_UI.ViewComponents.HomePage
{
    public class _DefaultBottomGridComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBottomGridComponentPartial (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessages = await client.GetAsync("https://localhost:7272/api/BottomGrid/GetAllBottomGrid");

            if (responceMessages.IsSuccessStatusCode)
            {
                var jsonData = await responceMessages.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultBottomGridDTOs>>(jsonData);

                return View(value);

            }

            return View();
        }
    }
}

