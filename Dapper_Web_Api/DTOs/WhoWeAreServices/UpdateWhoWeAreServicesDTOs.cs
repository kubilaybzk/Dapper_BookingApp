using System;
namespace Dapper_Web_Api.DTOs.WhoWeAreServices
{
	public class UpdateWhoWeAreServicesDTOs
	{
        public int WhoWeAreServiceID { get; set; }
        public string ServicesName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}

