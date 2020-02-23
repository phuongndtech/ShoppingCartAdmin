using AminShoppingCart.DTOs.ResponseDTOs;
using AminShoppingCart.Models.ViewModels;
using AutoMapper;

namespace AminShoppingCart.Models.MappingProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponseDTO, UserViewModel>();
            CreateMap<UserViewModel, UserResponseDTO>();
        }
    }
}
