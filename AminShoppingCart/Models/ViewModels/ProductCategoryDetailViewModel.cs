namespace AminShoppingCart.Models.ViewModels
{
    public class ProductCategoryDetailViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ImageFile{ get; set; }
    }
}