using AminShoppingCart.DTOs.ResponseDTOs;
using AminShoppingCart.Models.ViewModels;
using AutoMapper;

namespace AminShoppingCart.Models.MappingProfile
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandResponseDTO, BrandViewModel>();
            CreateMap<BrandViewModel, BrandResponseDTO>();
        }
    }
}
