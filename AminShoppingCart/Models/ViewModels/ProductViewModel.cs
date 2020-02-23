using AminShoppingCart.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AminShoppingCart.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<BrandResponseDTO> Brands { get; set; }
        public string ImageFileName { get; set; }
        public bool IsHot { get; set; }
        public string IsHot2 { get; set; }
    }
}
