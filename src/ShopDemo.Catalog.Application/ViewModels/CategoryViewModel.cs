﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShopDemo.Catalog.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public int Code { get; set; }
    }
}
