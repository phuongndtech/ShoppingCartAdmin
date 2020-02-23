using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AminShoppingCart.Services.IServices
{
    public interface IBrandService
    {
        Task<List<BrandResponseDTO>> GetBrands();
        Task<BrandResponseDTO> GetBrandDetail(int id);
        Task DeleteBrand(int id);
        Task CreateBrand(BrandRequestDTO request);
        Task UpdateBrand(BrandRequestDTO request);
    }
}
