using System;
using Dapper_Web_Api.DTOs.Product;

namespace Dapper_Web_Api.Repositorys
{
	public interface IProductRepository
	{
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync();
    }
}


