using System;
using Dapper_Web_Api.DTOs;

namespace Dapper_Web_Api.Repositorys
{
	public interface ICategoryRepository
	{
		Task <List<ResultCategoryDTO>> GetAllCategoryAsync();

		Task <bool> CreateOneCategory(CreateCategoryDTO createCategoryDTO);

		Task<bool> DeleteCategory(int id);

		Task<bool> UpdateCategory(UpdateCategoryDTO updateCategoryDTO);

		Task<ResultCategoryDTO> GetByIdCategory(int id);

    }
}

