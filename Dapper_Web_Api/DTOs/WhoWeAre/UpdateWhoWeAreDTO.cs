using System;
namespace Dapper_Web_Api.DTOs.WhoWeAre
{
	public class UpdateWhoWeAre
	{
        public int WhoWeAreDetailID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
    }
}

