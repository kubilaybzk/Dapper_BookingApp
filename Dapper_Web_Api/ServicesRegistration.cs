using System;
using Dapper_Web_Api.Concrete;
using Dapper_Web_Api.Concrete.BottomGrid;
using Dapper_Web_Api.Concrete.PopularLocation;
using Dapper_Web_Api.Concrete.Testimonial;
using Dapper_Web_Api.Concrete.WhoWeAre;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys;
using Dapper_Web_Api.Repositorys.BottomGrid;
using Dapper_Web_Api.Repositorys.PopularLocation;
using Dapper_Web_Api.Repositorys.Testimonial;
using Dapper_Web_Api.Repositorys.WhoWeAre;

namespace Dapper_Web_Api
{
	public static class ServicesRegistration
	{
        public static void AddServicesRegistration(this IServiceCollection collection)
        {
            collection.AddScoped<DapperContext>();
            collection.AddScoped<ICategoryRepository, CategoryRepository>();
            collection.AddScoped<IProductRepository, ProductRepository>();
            collection.AddScoped<IWhoWeAreRepository, WhoWeAreRepository>();
            collection.AddScoped<IWhoWeAreServicesRepository, WhoWeAreServicesRepositoy>();
            collection.AddScoped<IBottomGridRepository, BottomGridRepository>();
            collection.AddScoped<IPopularLocationRepository, PopularLocationRepository>();
            collection.AddScoped<ITestimonialRepository, TestimonialRepository>();
        }
	}
}

