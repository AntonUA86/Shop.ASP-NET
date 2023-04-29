using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.ASP_NET.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}

