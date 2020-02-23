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
    public class BrandService: IBrandService
    {
        private readonly HttpClient _httpClient;
        private readonly MyConfigure _configure;
        public BrandService(HttpClient httpClient, IOptions<MyConfigure> configure)
        {
            _httpClient = httpClient;
            _configure = configure.Value;
        }
        public async Task CreateBrand(BrandRequestDTO request)
        {
            var requestClient = JsonSerializer.Serialize<BrandRequestDTO>(request);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync($"{_configure.Url}Brand", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task DeleteBrand(int id)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{_configure.Url}Brand?id={id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task<BrandResponseDTO> GetBrandDetail(int id)
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}Brand/Id?id={id}");
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
            var items = JsonSerializer.Deserialize<BrandResponseDTO>(content, options);
            return items;
        }

        public async Task<List<BrandResponseDTO>> GetBrands()
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}Brand");
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
            var items = JsonSerializer.Deserialize<List<BrandResponseDTO>>(content, options);
            return items;
        }

        public async Task UpdateBrand(BrandRequestDTO request)
        {
            var requestClient = JsonSerializer.Serialize<BrandRequestDTO>(request);
            HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PutAsync($"{_configure.Url}Brand", content);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }
    }
}
