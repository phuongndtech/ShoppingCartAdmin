using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.DTOs.ResponseDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AminShoppingCart.Services.IServices
{
    public interface IUserService
    {
        Task<bool> Login(UserRequestDTO userRequest);
        Task CreateUser(UserRequestDTO userRequest);
        Task<List<UserResponseDTO>> GetUserList();
        Task<UserResponseDTO> GetUserDetail(int id);
        Task DeleteUser(int id);
        Task UpdateUser(UserRequestDTO userRequest);
    }
}
