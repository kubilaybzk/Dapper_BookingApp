using System;
namespace Dapper_Web_Api.DTOs
{
	public class CreateCategoryDTO
	{
		public string CategoryName { get; set; }
		public bool CategoryStatus { get; set; }
	}

}