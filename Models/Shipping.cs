using System;
using System.ComponentModel.DataAnnotations;

namespace Pronia2.Models
{
	public class Shipping
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Title { get; set; }
		[MaxLength(50)]
		public string Description { get; set; }
		public string Image { get; set; }
	}
}

