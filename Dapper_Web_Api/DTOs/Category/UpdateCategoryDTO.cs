using System;
namespace Dapper_Web_Api.DTOs
{
	public class UpdateCategoryDTO
	{
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }
    }
}

