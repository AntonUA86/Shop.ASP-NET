﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.ASP_NET.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Error")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}

