using AminShoppingCart.DTOs.ResponseDTOs;
using AminShoppingCart.Models.ViewModels;
using AutoMapper;

namespace AminShoppingCart.Models.MappingProfile
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryResponseDTO, CategoryViewModel>();
            CreateMap<CategoryViewModel, CategoryResponseDTO>();
        }
    }
}
