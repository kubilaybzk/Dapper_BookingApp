﻿using System;
namespace Dapper_Web_UI.Dtos.ProductDtos
{
	public class ResultProductDtos
	{
        public int productID { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string disctrict { get; set; }
        public string categoryName { get; set; }
    }
}

