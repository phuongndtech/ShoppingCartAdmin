using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AminShoppingCart.DTOs.RequestDTOs
{
    public class ProductRequestDTO
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
        [Required]
        public int? BrandId { get; set; }
        public bool IsHot { get; set; }
        public string IsHot2 { get; set; }
        public string ImageFileName { get; set; }
    }
}
