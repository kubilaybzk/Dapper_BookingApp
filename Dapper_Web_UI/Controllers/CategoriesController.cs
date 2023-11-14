using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper_Web_Api.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_Web_UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategorysAsync()
        {
            var categorys = await  _categoryRepository.GetAllCategoryAsync();
            return Ok(categorys);
        }

    }
}

