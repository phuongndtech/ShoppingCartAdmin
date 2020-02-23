using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.DTOs.ResponseDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AminShoppingCart.Services.IServices
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryResponseDTO>> GetProductCategories();
        Task<List<ProductCategoryResponseDTO>> GetProductCategoryDetail(int id);
        Task DeleteProductCategory(ProductCategoryRequestDTO request);
        Task CreateProductCategory(ProductCategoryRequestDTO request);
        Task UpdateProductCategory(ProductCategoryRequestDTO request);
    }
}
