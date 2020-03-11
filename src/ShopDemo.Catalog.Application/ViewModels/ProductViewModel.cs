﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopDemo.Catalog.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public DateTime RegisterDate { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Field {0} should have minimum value : {1}")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int StockQuantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Field {0} should have minimum value : {1}")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int Height { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Field {0} should have minimum value : {1}")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int Width { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Field {0} should have minimum value : {1}")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int Depth { get; set; }

        public IEnumerable<CategoryViewModel> Categorias { get; set; }
    }
}
