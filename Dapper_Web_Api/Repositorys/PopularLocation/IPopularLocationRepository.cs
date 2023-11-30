using System;
using Dapper_Web_Api.DTOs.PopularLocation;

namespace Dapper_Web_Api.Repositorys.PopularLocation
{
	public interface IPopularLocationRepository
	{
        Task<List<ResultPopularLocationDTOs>> GetAllPopularLocationAsync();
    }
}

