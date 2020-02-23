using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.DTOs.ResponseDTOs;
using AminShoppingCart.Models;
using AminShoppingCart.Services.IServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AminShoppingCart.Services.ImplementServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly MyConfigure _configure;
        public CategoryService(HttpClient httpClient, IOptions<MyConfigure> configure)
        {
            _httpClient = httpClient;
            _configure = configure.Value;
        }
        public async Task CreateCategory(CategoryRequestDTO request)
        {
            var requestClient = JsonSerializer.Serialize<CategoryRequestDTO>(request);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync($"{_configure.Url}Category", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task DeleteCategory(int id)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{_configure.Url}Category?id={id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task<List<CategoryResponseDTO>> GetCategories()
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}Category");
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
            var items = JsonSerializer.Deserialize<List<CategoryResponseDTO>>(content, options);
            return items;
        }

        public async Task<CategoryResponseDTO> GetCategoryDetail(int id)
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}Category/Id?id={id}");
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
            var items = JsonSerializer.Deserialize<CategoryResponseDTO>(content, options);
            return items;
        }

        public async Task UpdateCategory(CategoryRequestDTO request)
        {
            var requestClient = JsonSerializer.Serialize<CategoryRequestDTO>(request);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PutAsync($"{_configure.Url}Category", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }
    }
}
