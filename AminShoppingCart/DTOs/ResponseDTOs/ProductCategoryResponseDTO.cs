namespace AminShoppingCart.DTOs.ResponseDTOs
{
    public class ProductCategoryResponseDTO
    {
        public int BrandId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
