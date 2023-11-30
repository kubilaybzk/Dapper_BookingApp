using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper_Web_Api.DTOs.WhoWeAre;
using Dapper_Web_Api.DTOs.WhoWeAreServices;
using Dapper_Web_Api.Repositorys.WhoWeAre;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_Web_Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class WhoWeAreServicesController : Controller
    {
        private readonly IWhoWeAreServicesRepository _whoWeAreServicesRepository;

        public WhoWeAreServicesController(IWhoWeAreServicesRepository whoWeAreServicesRepository)
        {
            _whoWeAreServicesRepository = whoWeAreServicesRepository;
        }


        [HttpGet]
        public async Task<IActionResult> WhoWeAreServicesDetailList()
        {
            var values = await _whoWeAreServicesRepository.GetAllWhoWeAreServicesAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreServices(CreateWhoWeAreServicesDTOs createWhoWeAreServicesDTOs)
        {
            _whoWeAreServicesRepository.CreateWhoWeAreServices(createWhoWeAreServicesDTOs);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAreServices(int id)
        {
            _whoWeAreServicesRepository.DeleteWhoWeAreServices(id);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreServices(UpdateWhoWeAreServicesDTOs updateWhoWeAreServicesDTOs)
        {
            _whoWeAreServicesRepository.UpdateWhoWeAreServices(updateWhoWeAreServicesDTOs);
            return Ok("Hakkımızda Kısmı Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreServicesDetail(int id)
        {
            var value = await _whoWeAreServicesRepository.GetByIDWhoWeAreServices(id);
            return Ok(value);
        }



    }
}

