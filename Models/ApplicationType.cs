using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.ASP_NET.Models
{
	public class ApplicationType
	{
        [Key]
        public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}

