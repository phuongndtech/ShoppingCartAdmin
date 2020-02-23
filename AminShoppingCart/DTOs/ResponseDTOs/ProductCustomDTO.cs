using System.Collections.Generic;

namespace AminShoppingCart.DTOs.ResponseDTOs
{
    public class ProductCustomDTO
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public List<BrandResponseDTO> Brands { get; set; }
        public string CategoryName { get; set; }
        public bool IsHot { get; set; }
    }
}
