using System;
namespace GPRTU.Models
{
	public class Pickuploc
	{
        public int locId { get; set; }
        public string StationName { get; set; }
        public string Destinations { get; set; }
        public string TransVendors { get; set; }
        public string BusTerminals { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}

