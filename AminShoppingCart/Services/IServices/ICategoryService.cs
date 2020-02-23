using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AminShoppingCart.Services.IServices
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetCategories();
        Task<CategoryResponseDTO> GetCategoryDetail(int id);
        Task DeleteCategory(int id);
        Task CreateCategory(CategoryRequestDTO request);
        Task UpdateCategory(CategoryRequestDTO request);
    }
}
