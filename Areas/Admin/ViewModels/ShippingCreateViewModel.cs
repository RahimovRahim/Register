using System;
using System.ComponentModel.DataAnnotations;

namespace Pronia2.Areas.Admin.ViewModels
{
	public class ShippingCreateViewModel
	{
        public string Title { get; set; }
        [MaxLength(50)]
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
    }
}

