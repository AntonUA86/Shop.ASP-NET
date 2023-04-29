using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.ASP_NET.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}

