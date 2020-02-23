using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.DTOs.ResponseDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AminShoppingCart.Services.IServices
{
    public interface IProductSerivce
    {
        Task<List<ProductResponseDTO>> GetProducts();
        Task<ProductCustomDTO> GetProductById(int id);
        Task DeleteProduct(int id);
        Task CreateProduct(ProductRequestDTO productRequest);
        Task UpdateProduct(ProductRequestDTO productRequest);
    }
}
