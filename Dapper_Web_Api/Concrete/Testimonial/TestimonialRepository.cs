using System;
using Dapper;
using Dapper_Web_Api.DTOs.Testimonial;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys.Testimonial;

namespace Dapper_Web_Api.Concrete.Testimonial
{
    public class TestimonialRepository : ITestimonialRepository
    {

        private readonly DapperContext _context;

        public TestimonialRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDTOs>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDTOs>(query);
                return values.ToList();
            }
        }
    }
}

