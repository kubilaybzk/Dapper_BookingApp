using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper_Web_Api.DTOs;
using Dapper_Web_Api.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_Web_Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategory)
        {

            var values = await _categoryRepository.CreateOneCategory(createCategory);


            if (values)
            {
                return Ok("Ekleme işlemi başarılı");
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var result = await _categoryRepository.DeleteCategory(id);

            if (result) return Ok();
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task <IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var result = await _categoryRepository.UpdateCategory(updateCategoryDTO);

            if (result)
            {
                return Ok("Başarılı bir şekilde değişti");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetByIdCategory(int id)
        {
            ResultCategoryDTO result = await _categoryRepository.GetByIdCategory(id);

            if (result !=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}

