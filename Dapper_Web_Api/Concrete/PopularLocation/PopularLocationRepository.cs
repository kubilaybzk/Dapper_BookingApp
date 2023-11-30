using System;
using Dapper;
using Dapper_Web_Api.DTOs.PopularLocation;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys.PopularLocation;

namespace Dapper_Web_Api.Concrete.PopularLocation
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly DapperContext _context;
        public PopularLocationRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDTOs>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDTOs>(query);
                return values.ToList();
            }
        }
       
        
    }
}

