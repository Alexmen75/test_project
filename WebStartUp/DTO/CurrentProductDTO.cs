using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdventureWorks.DataBase;

namespace WebStartUp.DTO
{
	public class CurrentProductDTO
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string ProductNumber { get; set; }
		public byte[] LargePhoto { get; set; }
		public string LargePhotoFileName { get; set; }
		public string Description { get; set; }
		public int? ModelID { get; set; }
		public string Model { get; set; }
		public string Color { get; set; }
		public string Size { get; set; }
		public string SizeUnit { get; set; }
		public decimal? Weight { get; set; }
		public string ProductLine { get; set; }
		public string Class { get; set; }
		public string Style { get; set; }
		public int Count { get; set; }

	}
}