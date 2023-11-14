using System;
using Dapper_Web_Api.Concrete;
using Dapper_Web_Api.Models.DapperContext;
using Dapper_Web_Api.Repositorys;

namespace Dapper_Web_Api
{
	public static class ServicesRegistration
	{
        public static void AddServicesRegistration(this IServiceCollection collection)
        {
            collection.AddScoped<DapperContext>();
            collection.AddScoped<ICategoryRepository, CategoryRepository>();
            collection.AddScoped<IProductRepository, ProductRepository>();
        }
	}
}

