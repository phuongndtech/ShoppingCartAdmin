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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly MyConfigure _configure;
        public ProductCategoryService(HttpClient httpClient, IOptions<MyConfigure> configure)
        {
            _httpClient = httpClient;
            _configure = configure.Value;
        }

        public async Task CreateProductCategory(ProductCategoryRequestDTO request)
        {
            var requestClient = JsonSerializer.Serialize<ProductCategoryRequestDTO>(request);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync($"{_configure.Url}ProductCategory", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task DeleteProductCategory(ProductCategoryRequestDTO request)
        {
            var requestClient = JsonSerializer.Serialize(request);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync($"{_configure.Url}ProductCategory/DeleteProductCategory",content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task<List<ProductCategoryResponseDTO>> GetProductCategories()
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}ProductCategory");
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
            var items = JsonSerializer.Deserialize<List<ProductCategoryResponseDTO>>(content, options);
            return items;
        }

        public async Task<List<ProductCategoryResponseDTO>> GetProductCategoryDetail(int id)
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}ProductCategory/id?id={id}");
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
            var items = JsonSerializer.Deserialize<List<ProductCategoryResponseDTO>>(content, options);
            return items;
        }

        public async Task UpdateProductCategory(ProductCategoryRequestDTO request)
        {
            var requestClient = JsonSerializer.Serialize(request);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PutAsync($"{_configure.Url}ProductCategory", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }
    }
}