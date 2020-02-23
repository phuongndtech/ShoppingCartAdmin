using AminShoppingCart.DTOs.ResponseDTOs;
using AminShoppingCart.Models.ViewModels;
using AutoMapper;

namespace AminShoppingCart.Models.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductViewModel, ProductResponseDTO>();
            CreateMap<ProductResponseDTO, ProductViewModel>();
            CreateMap<ProductCustomDTO, ProductViewModel>();
            CreateMap<ProductViewModel, ProductCustomDTO>();
        }
    }
}
