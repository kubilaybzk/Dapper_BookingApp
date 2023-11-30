﻿using System;
namespace Dapper_Web_Api.DTOs.Product
{
	public class ResultProductWithCategoryDTO
	{
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverImage { get; set; }
        public string City { get; set; }
        public string Disctrict { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}

