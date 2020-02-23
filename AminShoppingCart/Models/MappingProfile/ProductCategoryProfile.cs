using AminShoppingCart.DTOs.ResponseDTOs;
using AminShoppingCart.Models.ViewModels;
using AutoMapper;

namespace AminShoppingCart.Models.MappingProfile
{
    public class ProductCategoryProfile:Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategoryResponseDTO, ProductCategoryViewModel>();
            CreateMap<ProductCategoryViewModel, ProductCategoryResponseDTO>();
            CreateMap<ProductCategoryDetailViewModel, ProductCategoryResponseDTO>();
            CreateMap<ProductCategoryResponseDTO, ProductCategoryDetailViewModel>();
        }
    }
}