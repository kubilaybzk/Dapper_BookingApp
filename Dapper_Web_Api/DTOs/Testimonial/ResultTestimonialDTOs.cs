﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Dapper_Web_Api.DTOs.Testimonial
{
	public class ResultTestimonialDTOs
	{
        public int TestimonialId { get; set; }
        
        public string NameSurname { get; set; }

        public string Title { get; set; }
      
        public string Comment { get; set; }

        public bool Status { get; set; }
    }
}

