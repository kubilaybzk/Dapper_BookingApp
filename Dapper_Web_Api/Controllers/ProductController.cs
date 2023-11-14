using Dapper_Web_Api.DTOs.Product;
using Dapper_Web_Api.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_Web_Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {

            var products = await _productRepository.GetAllProductAsync();

            if (products !=null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("GetAllProductWithCategory")]
        public async Task<IActionResult> GetAllProductWithCategory()
        {

            var products = await _productRepository.GetAllProductWithCategoryAsync();

            if (products != null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }

        }
    }
}

