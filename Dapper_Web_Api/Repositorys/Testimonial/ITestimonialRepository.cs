using System;
using Dapper_Web_Api.DTOs.Testimonial;

namespace Dapper_Web_Api.Repositorys.Testimonial
{
	public interface ITestimonialRepository
	{
        Task<List<ResultTestimonialDTOs>> GetAllTestimonialAsync();
    }
}

