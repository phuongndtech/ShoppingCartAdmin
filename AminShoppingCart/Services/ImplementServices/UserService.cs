using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.DTOs.ResponseDTOs;
using AminShoppingCart.Models;
using AminShoppingCart.Services.IServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AminShoppingCart.Services.ImplementServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly MyConfigure _configure;

        public UserService(HttpClient httpClient, IOptions<MyConfigure> configure)
        {
            _httpClient = httpClient;
            _configure = configure.Value;
        }
        public async Task<bool> Login(UserRequestDTO userRequest)
        {
            var requestClient = JsonSerializer.Serialize<UserRequestDTO>(userRequest);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync($"{_configure.Url}User/authenticate", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
            return true;
        }

        public async Task<List<UserResponseDTO>> GetUserList()
        {
            _httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1NzgwNTM3MzcsImV4cCI6MTY2NDQ1MzczNywiaWF0IjoxNTc4MDUzNzM3fQ.-S0z2oBCkZTsScu-iK0JC0c8Lc7cmlHtsiTOBLQQeik");

            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}User");
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var items = JsonSerializer.Deserialize<List<UserResponseDTO>>(content, options);
            return items;
        }

        public async Task<UserResponseDTO> GetUserDetail(int id)
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}User/Id?={id}");
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var item = JsonSerializer.Deserialize<UserResponseDTO>(content, options);
            return item;
        }

        public async Task DeleteUser(int id)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{_configure.Url}User?id={id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task UpdateUser(UserRequestDTO userRequest)
        {
            var requestClient = JsonSerializer.Serialize<UserRequestDTO>(userRequest);
            var id = userRequest.Id;
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync($"{_configure.Url}User/id?={id}", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task CreateUser(UserRequestDTO userRequest)
        {
            var requestClient = JsonSerializer.Serialize<UserRequestDTO>(userRequest);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync($"{_configure.Url}User", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }
    }
}
