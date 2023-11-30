using System;
using Dapper_Web_Api.DTOs.Testimonial;
using Dapper_Web_UI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dapper_Web_UI.ViewComponents.HomePage
{
	public class _DefaultOurClientsComponentPartial : ViewComponent
    {

        public IHttpClientFactory _httpClientFactory;

        public _DefaultOurClientsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {

      

            var client = _httpClientFactory.CreateClient();


           var responseMessage = await client.GetAsync("https://localhost:7272/api/Testimonial/GetAllTestimonials");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

          
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDTOs>>(jsonData);

                return View(values);

            }



            return View();
        }
    }
}

