﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        
        [Required]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Price must be higher than 0")]
        public decimal Price { get; set; }
        
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        
        [Required]
        public string PictureUrl { get; set; }
        
        [Required]
        public string Brand { get; set; }
        
        [Required]
        public string Type { get; set; }
    }
}