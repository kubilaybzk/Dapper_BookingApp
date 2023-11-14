﻿using System;
using System.Net;

namespace Dapper_Web_Api.DTOs.Product
{
	public class ResultProductDTO
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverImage { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }



    }
}

