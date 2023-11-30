
using Dapper_Web_Api.DTOs.BottomGrid;
using Dapper_Web_Api.Repositorys.BottomGrid;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_Web_Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class BottomGridController : ControllerBase
    {
        public readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBottomGrid()
        {
            var values = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottomGridById(int id)
        {
            var values = await _bottomGridRepository.GetBottomGridById(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDTOs createBottomGridDTOs)
        {
            _bottomGridRepository.CreateBottomGrid(createBottomGridDTOs);
            return Ok("Başarıyla eklendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            try
            {
                _bottomGridRepository.DeleteBottomGrid(id);
                return Ok("Başarıyla silindi");
            }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDTOs updateBottomGridDTOs)
        {
            _bottomGridRepository.UpdateBottomGrid(updateBottomGridDTOs);
            return Ok();
        }




    }
}

