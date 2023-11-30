using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper_Web_Api.DTOs.WhoWeAre;
using Dapper_Web_Api.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_Web_Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class WhoWeAreController : Controller
    {

        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreRepository.GetAllWhoWeAreAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDTO createWhoWeAreDto)
        {
            _whoWeAreRepository.CreateWhoWeAre(createWhoWeAreDto);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
            _whoWeAreRepository.DeleteWhoWeAre(id);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAre updateWhoWeAreDto)
        {
            _whoWeAreRepository.UpdateWhoWeAre(updateWhoWeAreDto);
            return Ok("Hakkımızda Kısmı Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var value = await _whoWeAreRepository.GetWhoWeAre(id);
            return Ok(value);
        }
    }
}

