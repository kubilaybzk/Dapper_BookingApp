using System;
using Dapper_Web_Api.DTOs;
using Dapper;
using System.Reflection.Metadata;
using Dapper_Web_Api.DTOs.Product;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys;

namespace Dapper_Web_Api.Concrete
{
    public class ProductRepository : IProductRepository
    {

        public readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDTO>> GetAllProductAsync()
        {

            string query = "Select * from Product";

            using (var connection = _context.CreateConnection())
            {
                var categorys = await connection.QueryAsync<ResultProductDTO>(query);

                return categorys.ToList();
            }


           
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync()
        {
            string query = "select top 6 ProductID,Title ,Price,CoverImage,City,Disctrict,Address,Description,CategoryName from Product inner join Category  on Product.ProductCategory = Category.CategoryID  ";

            using (var connection = _context.CreateConnection())
            {
                var categorys = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);

                return categorys.ToList();
            }
        }
    }
}

