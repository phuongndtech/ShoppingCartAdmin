using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.DTOs.ResponseDTOs;
using AminShoppingCart.Models;
using AminShoppingCart.Services.IServices;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AminShoppingCart.Services.ImplementServices
{
    public class ProductSerivce : IProductSerivce
    {
        private readonly HttpClient _httpClient;
        private readonly MyConfigure _configure;
        public ProductSerivce(HttpClient httpClient, IOptions<MyConfigure> configure)
        {
            _httpClient = httpClient;
            _configure = configure.Value;
        }

        public async Task<ProductCustomDTO> GetProductById(int id)
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}Product/Id?id={id}");
            var brandResponses = await _httpClient.GetAsync($"{_configure.Url}Brand");
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            if (!httpResponse.IsSuccessStatusCode && !brandResponses.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var brands = await brandResponses.Content.ReadAsStringAsync();
            var productItem = JsonSerializer.Deserialize<ProductResponseDTO>(content, options);
            var brandItems = JsonSerializer.Deserialize<List<BrandResponseDTO>>(brands, options);
            var productResponse = new ProductCustomDTO()
            {
                ProductId = productItem.ProductId,
                Price = productItem.Price,
                BrandId = productItem.BrandId,
                ProductName = productItem.ProductName,
                CategoryName = productItem.CategoryName,
                Description = productItem.Description,
                ImageFileName = productItem.ImageFileName,
                Brands = brandItems,
                IsHot = productItem.IsHot
            };

            return productResponse;
        }

        public async Task<List<ProductResponseDTO>> GetProducts()
        {
            var httpResponse = await _httpClient.GetAsync($"{_configure.Url}Product");
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
            var items = JsonSerializer.Deserialize<List<ProductResponseDTO>>(content, options);
            return items;
        }

        public async Task DeleteProduct(int id)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{_configure.Url}Product?id={id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
        }

        public async Task CreateProduct(ProductRequestDTO productRequest)
        {
            try
            {
                var image = productRequest.ImageFile;
                var imageName = string.Empty;

                if (image != null)
                {
                    imageName = productRequest.ImageFile.FileName;
                    #region Upload File
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\dist\\img", imageName);
                    FileStream newFile = new FileStream(path, FileMode.Create);
                    image.CopyTo(newFile);
                    newFile.Dispose();
                    FileStream openFile = File.OpenRead(newFile.Name);
                    var storageConnectionString = _configure.BlobStorageConnectionString;
                    var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                    var blobStorage = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobStorage.GetContainerReference("image");
                    CloudBlockBlob blob = container.GetBlockBlobReference(imageName);
                    blob.Properties.ContentType = image.ContentType;
                    await blob.UploadFromStreamAsync(openFile);
                    #endregion
                }

                var productRequestAPI = new ProductCreateModel()
                {
                    Name = productRequest.Name,
                    Price = productRequest.Price,
                    Description = productRequest.Description,
                    ImageFileName = imageName,
                    BrandId = productRequest.BrandId,
                    IsHot = productRequest.IsHot2 != null ? bool.Parse(productRequest.IsHot2) : productRequest.IsHot
                };

                var requestClient = JsonSerializer.Serialize(productRequestAPI);
                HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
                var httpResponse = await _httpClient.PostAsync($"{_configure.Url}Product", content);
                
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve tasks");
                }

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateProduct(ProductRequestDTO productRequest)
        {
            try
            {
                var image = productRequest.ImageFile;
                var imageName = string.Empty;
                var id = productRequest.ProductId;
                string path;

                if (image == null)
                {
                    imageName = productRequest.ImageFileName;
                }

                if (image != null)
                {
                    imageName = image.FileName;
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\dist\\img", imageName);
                    FileStream newFile = new FileStream(path, FileMode.Create);
                    image.CopyTo(newFile);
                    newFile.Dispose();
                    FileStream openFile = File.OpenRead(newFile.Name);
                    var storageConnectionString = _configure.BlobStorageConnectionString;
                    var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                    var blobStorage = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobStorage.GetContainerReference("image");
                    CloudBlockBlob blob = container.GetBlockBlobReference(imageName);
                    blob.Properties.ContentType = image.ContentType;
                    await blob.UploadFromStreamAsync(openFile);
                }

                var productRequestAPI = new ProductCreateModel()
                {
                    Name = productRequest.Name,
                    Price = productRequest.Price,
                    Description = productRequest.Description,
                    ImageFileName = imageName,
                    BrandId = productRequest.BrandId,
                    IsHot = productRequest.IsHot2 != null ? bool.Parse(productRequest.IsHot2) : productRequest.IsHot
                };

                var requestClient = JsonSerializer.Serialize<ProductCreateModel>(productRequestAPI);
                HttpContent content = new StringContent(requestClient, Encoding.UTF8, "application/json");
                var httpResponse = await _httpClient.PutAsync($"{_configure.Url}Product?id={id}", content);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve tasks");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}