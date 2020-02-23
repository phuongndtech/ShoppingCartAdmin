using Newtonsoft.Json;

namespace AminShoppingCart.DTOs.ResponseDTOs
{
    public class ProductResponseDTO
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("productName")]
        public string ProductName { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("imageFileName")]
        public string ImageFileName { get; set; }
        [JsonProperty("brandName")]
        public string BrandName { get; set; }
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
        [JsonProperty("brandId")]
        public int BrandId { get; set; }
        [JsonProperty("isHot")]
        public bool IsHot { get; set; }
        [JsonIgnore]
        public string Messages { get; set; }
    }
}
